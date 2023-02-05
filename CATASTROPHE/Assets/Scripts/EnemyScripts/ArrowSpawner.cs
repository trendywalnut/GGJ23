using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject projectile;

    [Header("Time Before Spawns Start")]
    [SerializeField] private float initWait;
    [Header("Time Between Spawns")]
    [SerializeField] private float waitTime;
    void Start()
    {
        Invoke(nameof(BeginSpawnCoroutine), initWait);
    }


    private void BeginSpawnCoroutine()
    {
        StartCoroutine(SpawnArrow());
    }

    IEnumerator SpawnArrow()
    {
        Instantiate(projectile, RandomSpawnPoint().position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(SpawnArrow());
    }

    private Transform RandomSpawnPoint()
    {
        int pointNum = Random.Range(0, spawnPoints.Length);

        return spawnPoints[pointNum].transform;
    }
}
