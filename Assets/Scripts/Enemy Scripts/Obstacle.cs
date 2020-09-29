using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    public int health = 100;

    [SerializeField]
    private float scrollSpeed;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float bound_Y;

    private float xScroll;

    private bool canRotate = true;
    private bool canMove = true;

    [SerializeField]
    private GameObject impactEffect;

    private void Start()
    {
        if(canRotate)
        {
            if(Random.Range(0, 2) > 0)
            {
                rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 20f);
                rotateSpeed *= -1f;
            }
        }
    }

    private void Update()
    {
        Fall();
        Rotate();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Instantiate(impactEffect, transform.position, transform.rotation);

        if(health <= 0)
        {
            Die();
        }
    }

    private void Fall()
    {
        xScroll = Time.time * scrollSpeed;
        transform.position = new Vector2(transform.position.x, xScroll);
    }    

    private void Rotate()
    {
        if(canRotate)
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, rotateSpeed * Time.deltaTime), Space.World);
        }
    }


    private void EnemyMovement()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            transform.position = temp;

            if (temp.y < bound_Y)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }


}
