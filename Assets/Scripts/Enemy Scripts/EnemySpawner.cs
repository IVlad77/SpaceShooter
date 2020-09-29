using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float min_X = -5.88f;
    private float max_X = 5.81f;

    [SerializeField]
    private GameObject[] asteroidPrefabs;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float timer = 2.0f;

    private void Start()
    {
        Invoke("SpawnEnemies", timer);
    }
    void SpawnEnemies()
    {
        float pos_X = Random.Range(min_X, max_X);
        Vector3 temp = transform.position;
        temp.x = pos_X;

        if(Random.Range(0, 2) > 0)
        {
            Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], temp, Quaternion.identity);
        } else
        {
            Instantiate(enemyPrefab, temp, Quaternion.Euler(0.0f, 0.0f, -180.0f));
        }

        Invoke("SpawnEnemies", timer);
    }
}
