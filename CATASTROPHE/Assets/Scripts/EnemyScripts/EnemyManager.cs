using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    public List<EnemyWave> waveList = new List<EnemyWave>();
    public GameObject enemySpawner;

    private EnemyWave currentWave;

    public int aliveEnemies;
    public int waveNumber;

    public bool allWavesFinished;

    [SerializeField] private float timeBetweenWaves;

    private float timer;

    private void OnEnable()
    {
        //Debug.Log("Enemy Manager Enabled");
        Instance = this;
        waveNumber = 0;
        allWavesFinished = false;

        currentWave = waveList[waveNumber];
        currentWave.totalEnemies = currentWave.meleeEnemiesToSpawn + currentWave.rangedEnemiesToSpawn;
        aliveEnemies = currentWave.totalEnemies;
        enemySpawner.GetComponent<EnemySpawner>().SpawnEnemies(currentWave);
    }

    private void Update()
    {
        if (aliveEnemies == 0)
        {
            //Debug.Log("Enemy Wave Defeated");
            timer += Time.deltaTime;
            if (waveNumber == waveList.Count - 1)
            {
                // Move on to next area
                allWavesFinished = true;
                //Debug.Log("Move Onto Next Area");
            }
            else if (timer >= timeBetweenWaves)
            {
                aliveEnemies = -1;
                timer = 0;

                waveNumber++;
                currentWave = waveList[waveNumber];
                enemySpawner.GetComponent<EnemySpawner>().SpawnEnemies(currentWave);
                currentWave.totalEnemies = currentWave.meleeEnemiesToSpawn + currentWave.rangedEnemiesToSpawn;
                aliveEnemies = currentWave.totalEnemies;
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
