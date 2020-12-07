using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    
    public int startingHealth = 100;
    public static int currentHealth=100;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;

    private Animator anim;
    private AudioSource enemyAudio;
    private ParticleSystem hitPatricles;
    private CapsuleCollider capsuleCollider;

    private bool isDead;
    private bool isSinkning;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitPatricles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        //currentHealth = startingHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (isSinkning)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage, Vector3 hitPoint)
    {
        if (isDead) { return; }
        
        enemyAudio.Play();

        currentHealth -= damage;

        hitPatricles.transform.position = hitPoint;
        hitPatricles.Play();

        if (currentHealth <= 0) { Death(); }


    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;
        
        anim.SetTrigger("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play();

    }

    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinkning = true;
        ScoreManager.score += scoreValue;
        Destroy(gameObject, 2f);
    }
    
    
}
