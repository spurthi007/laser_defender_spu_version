using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    private WaveConfigSO waveConfig;
    private EnemySpawner enemySpawner;
    private List<Transform> waypoints;
    private int currentPosition = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        transform.position = waveConfig.GetStartingWaypoint().position;
        waypoints = waveConfig.GetWaypoints();
    }

    void Update()
    {
        FollowPath();
    }

    public void FollowPath()
    {
        if (currentPosition < (waypoints.Count - 1))
        {
            float enemySpeed = waveConfig.GetMoveSPeed() * Time.deltaTime;
            Vector3 targetPosition = waypoints[currentPosition + 1].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemySpeed);
            if (transform.position == targetPosition)
            {
                currentPosition++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // if (currentPosition < waypoints.Count)
    // {
    //     Vector3 targetPosition = waypoints[currentPosition].position;
    //     float delta = waveConfig.GetMoveSPeed() * Time.deltaTime;
    //     transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
    //     if (transform.position == targetPosition)
    //     {
    //         currentPosition++;
    //     }
    // }
    // else
    // {

    //     Destroy(gameObject);
    // }

}
