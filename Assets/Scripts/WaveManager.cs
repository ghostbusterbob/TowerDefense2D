using TMPro;
using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveCounter;
    [SerializeField] private int waveIndex;

    public int enemiesAlive;
    
    [SerializeField] private RespawnEnemy respawnEnemy;
    [SerializeField] private Transform respawnPoint;

    [SerializeField] private float spawnInterval = 0.5f; // delay between enemy spawns

    private void Start()
    {
        enemiesAlive = 1; // start with 1 enemy
        waveIndex = 1;
        UpdateWaveText();
    }

    public void IncreaseWave()
    {
        waveIndex++;
        UpdateWaveText();
        RespawnEnemy(waveIndex); // call wrapper (keeps old references working)
        Debug.Log("Increasing Wave");
    }

    private void UpdateWaveText()
    {
        waveCounter.text = "Wave: " + waveIndex;
    }

    public void IncreaseEnemies()
    {
        enemiesAlive++;
        Debug.Log("Alive: " + enemiesAlive);
    }

    public void DecreaseEnemies()
    {
        enemiesAlive--;
        Debug.Log("Decreasing Enemies: " + enemiesAlive);

        if (enemiesAlive <= 0)
        {
            IncreaseWave();
        }
    }

    public int GetEnemyCountForNextWave()
    {
        return waveIndex; // wave 1 = 1 enemy, wave 2 = 2 enemies, etc.
    }

    // --- Backward-compatible wrapper method ---
    public void RespawnEnemy(int enemyCount)
    {
        // Start coroutine with delay between spawns
        StartCoroutine(RespawnEnemiesWithDelay(enemyCount));
    }

    // --- Coroutine to handle delayed spawns ---
    private IEnumerator RespawnEnemiesWithDelay(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            respawnEnemy.SpawnEnemy(respawnPoint.position);
            IncreaseEnemies();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}