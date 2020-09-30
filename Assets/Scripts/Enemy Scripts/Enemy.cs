using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float xScroll;

    [SerializeField]
    private float scrollSpeed;

    [SerializeField]
    private float bound_Y;

    private int score = 0;

    [SerializeField]
    private bool canShoot;
    [SerializeField]
    private bool canRotate;

    private bool canMove = true;

    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject explosionEffect;

    private Text isScore;

    private void Start()
    {
        

        if (canRotate)
        {
            if (Random.Range(0, 2) > 0)
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
        }

        if (canShoot)
        {
            Invoke("StartShooting", Random.Range(0.5f, 1.0f));
        }
    }



    private void Update()
    {

        EnemyMovement();
        Rotate();

    }
    private void EnemyMovement()
    {
        if(canMove)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            transform.position = temp;

            if(temp.y < bound_Y)
            {
                Destroy(gameObject);
            }
        }
    }


    private void Rotate()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, rotateSpeed * Time.deltaTime), Space.World);
        }
    }

    void StartShooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().isEnemyBullet = true;

        if(canShoot)
        {
            Invoke("StartShooting", Random.Range(1.0f, 3.0f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        
        if(collision.tag == "Bullet")
        {

            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
