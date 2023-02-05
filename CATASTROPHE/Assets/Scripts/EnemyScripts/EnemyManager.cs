using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    public List<EnemyWave> waveList = new List<EnemyWave>();
    public GameObject enemySpawner;

    public int aliveEnemies;
    public int waveNumber;

    [SerializeField] private float timeBetweenWaves;

    private float timer;

    private void OnEnable()
    {
        Debug.Log("Enemy Manager Enabled");
        Instance = this;
        waveNumber = 0;
        aliveEnemies = waveList[waveNumber].totalEnemies;
        enemySpawner.GetComponent<EnemySpawner>().SpawnEnemies(waveList[waveNumber]);
    }

    private void Update()
    {
        if (aliveEnemies == 0)
        {
            Debug.Log("Enemy Wave Defeated");
            timer += Time.deltaTime;
            if (timer >= timeBetweenWaves)
            {
                aliveEnemies = -1;
                timer = 0;

                if (waveNumber == waveList.Count)
                {
                    // Move on to next area
                }
                else
                {
                    waveNumber++;
                    enemySpawner.GetComponent<EnemySpawner>().SpawnEnemies(waveList[waveNumber]);
                    aliveEnemies = waveList[waveNumber].totalEnemies;
                }
            }
        }
    }
}

[System.Serializable]
public class EnemyWave
{
    public int meleeEnemiesToSpawn;
    public int rangedEnemiesToSpawn;
    public int totalEnemies;

    public EnemyWave (int meleeToSpawn, int rangedToSpawn, string name)
    {
        meleeEnemiesToSpawn = meleeToSpawn;
        rangedEnemiesToSpawn = rangedToSpawn;
        totalEnemies = meleeEnemiesToSpawn + rangedEnemiesToSpawn;
    }
}
