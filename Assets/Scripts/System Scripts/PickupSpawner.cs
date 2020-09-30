using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    private float min_X = -5.88f;
    private float max_X = 5.81f;

    [SerializeField]
    private float timer = 2.0f;

    [SerializeField]
    private GameObject shieldPickup;


    private void Start()
    {
        Invoke("SpawnPickup", timer);
    }
    void SpawnPickup()
    {
        float pos_X = Random.Range(min_X, max_X);
        Vector3 temp = transform.position;
        temp.x = pos_X;

        if (Random.Range(0, 2) > 0)
        {
            Instantiate(shieldPickup, temp, Quaternion.identity);
        }

        Invoke("SpawnPickup", timer);
    }
}
