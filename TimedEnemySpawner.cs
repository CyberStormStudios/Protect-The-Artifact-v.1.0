using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimedEnemySpawner : MonoBehaviour
{
    [Tooltip("How far into the game this spawner should activate")]
    [SerializeField] private float _startAtSeconds;
    [Tooltip("How far into the game this spawner should de-activate (should be higher than start)")]
    [SerializeField] private float _stopAtSeconds = 9999;

    [Tooltip("How often in seconds the thing spawns")]
    [SerializeField] private float _spawnRate = 5f;

    [SerializeField] private float SpawnTimer = 0f;

    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField]private int minEnemiesToSpawn = 3;
    [SerializeField]private int maxEnemiesToSpawn = 10;



    private float _timeSinceLevelStarted;
    private float _spawnTimer;

    private void OnEnable()
    {
        _spawnTimer = 0f;
        _timeSinceLevelStarted = 0f;        
    }


    private void Update()
    {
        _timeSinceLevelStarted += Time.deltaTime;

        if (_timeSinceLevelStarted >= _startAtSeconds && _timeSinceLevelStarted <= _stopAtSeconds)
            TickSpawning();
    }

    private void TickSpawning()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _spawnRate)
            Spawn();
    }

    public void Spawn()
     {
        _spawnTimer = 0f;

        int numberOfEnemiesToSpawn = UnityEngine.Random.Range(minEnemiesToSpawn, maxEnemiesToSpawn);
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
       {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            

       }

   }
}
