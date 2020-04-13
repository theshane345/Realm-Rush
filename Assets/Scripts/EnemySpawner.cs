using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] GameObject enemyPrefab;

    void Start()
    {
        StartCoroutine(RepteadlySpawnEnemies());
        //sta co-routine
    }

    
    IEnumerator RepteadlySpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawns);

        }
    }
}
