using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9f;
    public int enemyCount;
    public int waveNumber;

    public TextMeshProUGUI waveCountText;
    private int displayedWaveNumber;

    public TextMeshProUGUI highScoreText;

    private bool canCount;

    //public int scoreFactor; // multiplicar la oleada de forma procedural
    //public TextMeshPro scoreText; // agrega un TextMeshPro para mostrar el puntaje

    // Start is called before the first frame update
    void Start()
    {
        waveNumber = 1;
        displayedWaveNumber = 1;
        //scoreFactor = 0;
        waveCountText.text = "Wave: " + displayedWaveNumber;

        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);

        UpdateHighScoreText();
        //UpdateScoreText(); // Actualiza el puntaje en pantalla
        canCount = true;
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), transform.rotation);
        }
    }

    public void WaveCount()
    {
            displayedWaveNumber++;
            waveCountText.text = "Wave: " + displayedWaveNumber;
    }

    public void HighScore()
    {
        if (waveNumber > PlayerPrefs.GetInt("HighScore", 1))
        {
            PlayerPrefs.SetInt("HighScore", waveNumber);
        }
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 1)}";
    }

    //private void UpdateScoreText()
    //{
    //    scoreText.text = $"Score: {scoreFactor}";
    //}

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0 && GameManager.Instance.isGameOver == false && canCount)
        {
            waveNumber++;

            //scoreFactor += 100;
            //UpdateScoreText();
            //UpdateHighScoreText();

            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            WaveCount();
            HighScore();
        }

        if (GameManager.Instance.isGameOver == true)
        {
            canCount = false;
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);

        // Como este no es un método void sino una función tipo Vector3, necesitamos que retorne un valor para poderlo ejecutar en el void Start
        return randomPosition;
    }
}
