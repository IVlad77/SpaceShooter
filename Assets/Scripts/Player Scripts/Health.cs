using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float shield = 0.0f;
    [SerializeField]
    private int shieldStack = 0;

    [SerializeField]
    private GameObject shieldPrefab;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Transform respawnPoint;

    private GameObject go;

    
    Renderer rend;

    private int damage = 15;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    private void Update()
    {
        ShieldPowerUp();
    }

        

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if((collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "Enemy") && shield > 0)
        {
            ShieldDamage(damage);
        }
        else if(collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "Enemy")
        {
            PlayerTakeDamage(damage);
        }


        if (collision.gameObject.tag == "Pickup")
        {

            shieldStack += 1;

        }

    }


    

    private void PlayerTakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            StartCoroutine(Dead());
            
        }
    }

    public void ShieldPowerUp()
    {

        if (Input.GetKeyDown(KeyCode.C) && shieldStack > 0)
        {
            shield = 100.0f;
            go = Instantiate(shieldPrefab, transform.position, transform.rotation);
            go.transform.parent = this.transform;
            shieldStack -= 1;
        }
        
    }

    public void ShieldDamage(int damage)
    {
        shield -= damage;

        if (shield <= 0)
        {
            Destroy(go);
        }
    }

    IEnumerator Dead()
    {
        Debug.Log("dead");
        rend.enabled = false;
        yield return new WaitForSeconds(5);
        Debug.Log("respawn");
        playerTransform.position = respawnPoint.position;
        rend.enabled = true;
        health = 100.0f;
    }


}
