using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    /*[SerializeField]
    private float deactivateTimer = 3.0f;*/


    [HideInInspector]
    public bool isEnemyBullet = false;

   


    private void Start()
    {

        if(isEnemyBullet)
        {
            speed *= -1.0f;
        }

        Invoke("DeactivateGameObject", 3.0f);

    }

    private void Update()
    {
        Move();
       
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        transform.position = temp;
    }

    void DeactivateGameObject()
    {
        
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if(collision.tag == "Bullet" || collision.tag == "Enemy")
        {
            
            Destroy(gameObject);
            
            
        }
    }
}
