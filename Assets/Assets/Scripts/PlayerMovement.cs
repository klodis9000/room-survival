using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 6f;

    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRB;
    private int floorMask;
    private float camRayLength = 100f; //расстояние камеры от персонажа


    // Start is called before the first frame update
    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(horizontal,vertical);
        Turning();
        Animating(horizontal,vertical);

    }

    void Move(float horizontal,float vertical)
    {
        movement.Set(horizontal,0f,vertical);

        movement = movement.normalized * speed * Time.deltaTime; //нормализую вектор движения

        playerRB.MovePosition(transform.position + movement);
    }

    void Turning() //вращение игрока
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition); //луч вращения игрока за мышью

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRoration = Quaternion.LookRotation(playerToMouse);
            playerRB.MoveRotation(newRoration);
        }


    }

    void Animating(float horizontal, float vertical)
    {
        bool walk = horizontal != 0 || vertical != 0f;
        anim.SetBool("Walk", walk);
    }
    
    
    
    
}
