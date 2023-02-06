using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    [SerializeField] private AudioClip waveSFX;
    public List<EnemyWave> waveList = new List<EnemyWave>();
    public GameObject enemySpawner;

    private EnemyWave currentWave;

    public int aliveEnemies;
    public int waveNumber;

    public bool allWavesFinished;
    public bool dontLoadLevel = false;

    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private int levelToLoad;

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
                //sfx
                AudioManager.instance.WaveCompletePlayer(waveSFX);
                allWavesFinished = true;
                if (!dontLoadLevel)
                    LevelManager.instance.ChangeLevel(levelToLoad);
                
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
