using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    [SerializeField]
    private Transform bullet;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject firingEffect;


    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ShootProjectile();
        }

       
        
    }
    public void ShootProjectile()
    {
        Instantiate(firingEffect, firePoint.position, firePoint.rotation);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
