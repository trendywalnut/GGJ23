using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    [SerializeField] private GameObject[] meleeEnemy;
    [SerializeField] private GameObject[] rangedEnemy;
    [SerializeField] private GameObject[] rangedAggroEnemy;

    [SerializeField] private List<Transform> enemySpawners = new List<Transform>();

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnEnemies(EnemyWave waveToSpawn)
    {
        // Spawn Melee Enemies
        for (int i = 0; i < waveToSpawn.meleeEnemiesToSpawn; i++)
        {
            Transform spawnerToUse = ChooseRandomEnemySpawner();
            Instantiate(meleeEnemy[Random.Range(0, meleeEnemy.Length)], spawnerToUse.position, Quaternion.identity);
        }

        // Spawn Melee Enemies (30% chance to spawn aggro version)
        for (int i = 0; i < waveToSpawn.rangedEnemiesToSpawn; i++)
        {
            Transform spawnerToUse = ChooseRandomEnemySpawner();
            int chooseRanged = Random.Range(0, 10);

            if (chooseRanged <= 2)
            {
                Instantiate(rangedAggroEnemy[Random.Range(0, rangedAggroEnemy.Length)], spawnerToUse.position, Quaternion.identity);
            }
            else
            {
                Instantiate(rangedEnemy[Random.Range(0, rangedEnemy.Length)], spawnerToUse.position, Quaternion.identity);
            }
        }
    }

    private Transform ChooseRandomEnemySpawner()
    {
        Transform temp = enemySpawners[Random.Range(0, enemySpawners.Count)];
        return temp;
    }
}
