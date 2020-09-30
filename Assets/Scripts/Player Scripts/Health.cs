using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private int currentShield = 0;
    [SerializeField]
    private int maxShield = 100;
    [SerializeField]
    private int shieldStack = 0;

    [SerializeField]
    private GameObject shieldPrefab;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Transform respawnPoint;

    private GameObject go;

    public ShieldBar shieldBar;
    public HealthBar healthBar;
    Renderer rend;

    private int damage = 15;

    private void Start()
    {
        currentShield = 0;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    private void Update()
    {
        ShieldPowerUp();
    }

        

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Bullet") && currentShield > 0)
        {
            ShieldDamage(damage);
        }
        else if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Bullet")
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
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            StartCoroutine(Dead());
            
        }
    }

    public void ShieldPowerUp()
    {

        if (Input.GetKeyDown(KeyCode.C) && shieldStack > 0)
        {
            currentShield = maxShield;
            shieldBar.SetMaxShield(maxShield);
            go = Instantiate(shieldPrefab, transform.position, transform.rotation);
            go.transform.parent = this.transform;
            shieldStack -= 1;
        }
        
    }

    public void ShieldDamage(int damage)
    {
        currentShield -= damage;

        shieldBar.SetShield(currentShield);

        if (currentShield <= 0)
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
        currentHealth = maxHealth;
        rend.enabled = true;
    }

  
}
