using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    
    //private EnemyHealth enemyHealth;
    private PlayerHealth playerHealth;
    private NavMeshAgent nav;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        //к player не крепится свойство transform, позже узнать почему. пока оставлю [SerializeField]
        //player = GameObject.FindGameObjectsWithTag("Player").transform;

        nav = GetComponent<NavMeshAgent>();
        playerHealth = GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position); //устанавливаю путь к которому врагу необходимо двигаться
        }
        else
        {
            nav.enabled = false;
        }
    }
}
