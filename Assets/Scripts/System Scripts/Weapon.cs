using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float timer;

    [SerializeField]
    private int damage;

    
   

    private void Start()
    {
        rb.velocity = transform.up * speed;

    }

    private void Update()
    {
        timer += 1.0f * Time.deltaTime;
        BulletDestroy();

    }

    private void BulletDestroy()
    {
        if (timer >= 4)
        {
            Destroy(gameObject);
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if(collision.gameObject.tag == "Enemy")
        {
            
            Destroy(gameObject);
        }

    }


}
