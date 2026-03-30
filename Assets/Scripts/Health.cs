using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public int health = 100;
    [SerializeField] ParticleSystem blastEffect;

    Vector3 hitPosition;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    public bool isEnemy;
    int takeDamage = 0;
    void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        //scoreKeeper = new();
        levelManager = FindObjectOfType<LevelManager>();
        //ui = FindObjectOfType<UIBehaviour>();
        //Debug.Log("isEnemy for game object " + gameObject + " is " + enemy);
    }

    void LateUpdate()
    {
        // if (isEffectEnabled)
        // {

        //     HitEffect();
        // }
        hitPosition = transform.position;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<DamageDealer>())
        {
            DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
            int damageTaken = damageDealer.Damage;
            TakeDamage(damageTaken);
            

            audioPlayer.PlayExplosionClip();
            //audioPlayer.GetInstance().PlayShootingClip();
            //isEffectEnabled = true;
            HitEffect();
            PlayCameraEffect();
            damageDealer.Hit();


        }
    }

    private void TakeDamage(int damage)
    {
        // if (!isEnemy)
        // {
        //     takeDamage++;
        //      Debug.Log("Damage being taken is " + takeDamage);
        // }

        if (health > 0)
        {
            health -= damage;
            if (health == 0)
            {
                if (isEnemy)
                {
                    scoreKeeper.AddScore();
                }
                else
                {
                    levelManager.LoadEndScreen();
                    
                }
                Destroy(gameObject);
                
            }
            //Debug.Log("Health is " + health + " and the health is being reduced to " + gameObject);
        }
        else
        {
            Debug.Log("Destroyed " + gameObject);
            
            Destroy(gameObject);
        }
    }

    private void HitEffect()
    {
        ParticleSystem effect = Instantiate(blastEffect, hitPosition, Quaternion.identity);
        effect.Play();
        Destroy(effect.gameObject, effect.main.duration + effect.main.startLifetime.constantMax); // Because you want the effect to play for the duration
                                                                                                  // + if a particle spawan at the very lasts econd it should
                                                                                                  // finish it's lifecycle 
                                                                                                  //isEffectEnabled = false;

    }

    private void PlayCameraEffect()
    {
        if (gameObject.GetComponent<Player>() && cameraShake != null)
        {
            //Debug.Log("Is it coming here?");
            cameraShake.ShakeCamera();
        }
    }

    public int GetHealth()
    {
        return health;
    }

}
