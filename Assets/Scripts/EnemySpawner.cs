using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    WaveConfigSO currentWave;
    [SerializeField] float waveSpawnTime = 1f;
    float enemySpawnTime;
    [SerializeField] bool isLooping = true;

    private void Start()
    {
        StartCoroutine(SpawnWaves(waveSpawnTime));
    }

    IEnumerator SpawnWaves(float waveSpawnTime)
    {
        do
        {
            foreach (WaveConfigSO waveConfig in waveConfigs)
            {
                currentWave = waveConfig;
                enemySpawnTime = currentWave.GetEnemySpawnTime();
                StartCoroutine(SpawnEnemies(enemySpawnTime));
                yield return new WaitForSeconds(waveSpawnTime);
            }
        }
        while (isLooping);
    }

    IEnumerator SpawnEnemies(float enemySpawnTime)
    {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
            yield return new WaitForSeconds(enemySpawnTime);
        }
    }



    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

}
