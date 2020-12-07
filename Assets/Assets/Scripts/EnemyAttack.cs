using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBeetwenAttacks = 0.5f;
    public int attackDamage = 10; //наносимый урон

    private Animator anim;
    private GameObject player;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    private bool playrInRange; //входит ли игрок в диапазон атаки игрока
    private float timer;
    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= timeBeetwenAttacks && playrInRange && EnemyHealth.currentHealth > 0) 
        {
            Attack();
        }

        if (playerHealth.currentHealth < 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playrInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playrInRange = false;
        }
    }

    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0) //если текущее здоровье больше 0
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
