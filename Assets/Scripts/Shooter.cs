using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    // [SerializeField] GameObject playerProjectile;
    // [SerializeField] float projectileSpeed = 10f;

    [SerializeField] GameObject projectile;
    [SerializeField] float projSpeed = -20.0f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float minFiringRate = 0.1f;
    [SerializeField] float maxFiringRate = 1f;

    public bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
    }
    


    void Start()
    {
        
        //Debug.Log("Projectile speed in start() " + projSpeed+" and the firing rate is "+fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (projectile.layer == LayerMask.NameToLayer("Enemy") && firingCoroutine is null)
        {
            
            firingCoroutine = StartCoroutine(EnemyFiring());
        }
        // else if(firingCoroutine != null)
        // {
        //     StopCoroutine(firingCoroutine);
        //     //firingCoroutine = null;
        // }
        //Fire();
    }
    //Instructor's version
    // void Fire()
    // {
    //     if (isFiring && firingCoroutine == null)
    //     {
    //         firingCoroutine = StartCoroutine(FireContinuously(firingRate));
    //     }
    //     else if(!isFiring && firingCoroutine != null)
    //     {
    //         StopCoroutine(firingCoroutine);
    //         firingCoroutine = null;
    //     }
    // }
    // IEnumerator FireContinuously(float firingRate)
    // {
    //     while (true)
    //     {
    //         GameObject instance = Instantiate(playerProjectile, transform.position, Quaternion.identity);
    //         Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
    //         if (rb != null)
    //         {
    //             rb.velocity = transform.up * projectileSpeed;
    //         }
    //         Destroy(instance, projectileLifetime);
    //         yield return new WaitForSeconds(firingRate);
    //     }



    // }

    public void Firing()
    {
        GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);
        

        Rigidbody2D projectileRigidbody = instance.GetComponent<Rigidbody2D>();

        if (projectileRigidbody != null)
        {
            //projectileRigidbody.velocity = new Vector2(transform.position.x, transform.position.y * projectileSpeed);
            projectileRigidbody.velocity = transform.up * projSpeed;
        }
        //projectileRigidbody.drag = 0f;
        //Debug.Log("Printing rigidbody velocity" + projectileRigidbody.velocity + " and speed is " + projSpeed);
       audioPlayer.PlayShootingClip();
    }

    IEnumerator EnemyFiring()
    {
       
        Firing();
        float firingRate = Random.Range(minFiringRate, maxFiringRate);
        //Debug.Log("Firing rate is "+firingRate);
        yield return new WaitForSeconds(firingRate);
        firingCoroutine = null;

    }
}
