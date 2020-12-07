using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public int damage = 20;
    public float timeBeetwenBullets = 0.15f; //задержка между выстрелами
    public float range = 100f; //дальность

    private float timer;
    private Ray shootRay; //луч
    private RaycastHit shootHit; //объект с которым луч столкнулся
    private int shootableMask; //стреляющая маска
    private ParticleSystem gunParticles;
    private LineRenderer gunLine;
    private AudioSource gunAudio;
    private Light gunLight;
    private float effectsDisplayTime = 0.2f;

    // Start is called before the first frame update
    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBeetwenBullets)
        {
            Shoot();
        }

        //отключение эффекта выстрела
        if (timer >= timeBeetwenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
        
        
    }

    void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true; //включаю рендер лучей
        gunLine.SetPosition(0, transform.position); //задаю начальную позицию в начало пистолета

        shootRay.origin = transform.position; //место вылета луча
        shootRay.direction = transform.forward; //направление луча

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask)) //луч ! инфо о том, что достиг цели !  длина луча ! маска в которую луч попал
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage, shootHit.point);
            }

            gunLine.SetPosition(1, shootHit.point);

        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range); //иначе лучу лететь дальше
        }


    }

    public void DisableEffects()
    {
        gunLight.enabled = false;
        gunLine.enabled = false;
    }
    
    
    
    
    
    
}
