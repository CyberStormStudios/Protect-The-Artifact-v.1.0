using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimedEnemySpawner : MonoBehaviour
{
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimedEnemySpawner : MonoBehaviour
{
    public float spawnRate;
    public float maxTime;
    [SerializeField]private float distanceDelay;
    public GameObject enemyPrefab;

    private float time;
    private bool spawn;
    private float rate;
    [SerializeField]private int minEnemies;
    [SerializeField]private int maxEnemies;

    void Start()
    {
        spawn = true;
        distanceDelay = Random.Range(5, 8);
            
    }

    void Update()
    {
        //time += Time.deltaTime;
        //if (time >= maxTime)
        //{
            //StopAllCoroutines();
            //enabled = false;
           // return;
        //}

        if (spawn)
        {
            rate += Time.deltaTime;
            if (rate >= spawnRate)
            {
                spawn = false;
                rate = 0f;
                StartCoroutine(Spawn(Random.Range(minEnemies, maxEnemies + 1)));
            }
        }
    }

    IEnumerator Spawn(int amount)
    {
        if (amount == 1)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            spawn = true;
            yield break;
        }

        for (int i = 0; i < amount; i++)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(distanceDelay);
        }

        spawn = true;
    }
}
