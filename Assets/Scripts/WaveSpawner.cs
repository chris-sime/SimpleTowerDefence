using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour {

    public static int EnemiesAlive = 0;


    public Wave[] Waves;
    [Space]
    public Transform spawnLocation;
    
    [Space]
    public float timeBetweenWaves = 10.5f;
    public float initialCountdown = 5.5f;
    public int waveIndex = 0;

    UIManager UiManager;
    [Space]
    public GameManager gameManager;

    public List<GameObject> enemiesToSpawn;

    void Start () {
        UiManager = UIManager.instance;
        //if (this.enabled == false) this.enabled = true;
        EnemiesAlive = 0;
	}
	
	void Update () {

        if (EnemiesAlive > 0)
        {
            UiManager.CountdownUi.text = "--";
            return;
        }

        if (waveIndex == Waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (initialCountdown <= 0)
        {
            CreateListOfEnemiesToSpawn();            
            initialCountdown = timeBetweenWaves;
        }

        initialCountdown = Mathf.Clamp(initialCountdown, 0f, Mathf.Infinity);
 
        UiManager.CountdownUi.text = string.Format("{0:00}", initialCountdown);
        initialCountdown -= Time.deltaTime;

        UiManager.CurrentWaveUi.text = PlayerStats.WavesSurvived.ToString();    
	}

    IEnumerator SpawnWave(List<GameObject> shuffledEnemies)
    {
        
        PlayerStats.WavesSurvived++;
        Debug.Log(PlayerStats.WavesSurvived);
        Wave wave = Waves[waveIndex];
        EnemiesAlive = shuffledEnemies.ToArray().Length;
        Debug.Log(EnemiesAlive);
        foreach (GameObject enemy in shuffledEnemies)
        {
            SpawnEnemy(enemy);
            yield return new WaitForSeconds(1 / wave.rate);
        }
        waveIndex++;
        
    }

    void SpawnEnemy(GameObject  enemy)
    {
        Instantiate(enemy, spawnLocation.position, spawnLocation.rotation);       
    }


    void CreateListOfEnemiesToSpawn()
    {
        enemiesToSpawn.Clear();
        Wave wave = Waves[waveIndex];
        for (int i = 0; i < wave.Enemy.Length; i++)
        {
            for (int y = 0; y < wave.count[i]; y++)
            {
                enemiesToSpawn.Add(wave.Enemy[i]);
            }
        }

        StartCoroutine(SpawnWave(ShuffleEnemies(enemiesToSpawn)));
    }

    public List<GameObject> ShuffleEnemies(List<GameObject> shuffledList)
    {

        System.Random _random = new System.Random();

        GameObject myGO;

        int n = shuffledList.Count;
        for (int i = 0; i < n; i++)
        {
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
            int r = i + (int)(_random.NextDouble() * (n - i));
            myGO = shuffledList[r];
            shuffledList[r] = shuffledList[i];
            shuffledList[i] = myGO;
        }

        return shuffledList;
    }
}
