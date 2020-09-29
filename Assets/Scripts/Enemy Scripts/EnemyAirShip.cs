using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirShip : MonoBehaviour
{
    [SerializeField]
    public int health = 100;

    [SerializeField]
    private GameObject impactEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(impactEffect, transform.position, transform.rotation);

        if (health <= 0)
        {
            Die();
        }
    }

    

    private void Die()
    {
        Destroy(gameObject);
    }
}
