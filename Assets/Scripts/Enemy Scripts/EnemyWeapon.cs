using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float timer;

    [SerializeField]
    private int damage;

    EnemyAirShip enemy;


    private void Start()
    {
        rb.velocity = transform.up * speed;
        enemy = GetComponent<EnemyAirShip>();


    }

    private void Update()
    {
        timer += 1.0f * Time.deltaTime;
        BulletDestroy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            
            Destroy(gameObject);
        }
    }

    private void BulletDestroy()
    {
        if (timer >= 4)
        {
            Destroy(gameObject);
        }
    }
}
