using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target; //за кем следить
    public float smoothing = 5f; //сглаживание

    private Vector3 offset; //смещение камеры
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset; 
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime); //движение за игроком
    }
    
    
    
    
    
    
    
}
