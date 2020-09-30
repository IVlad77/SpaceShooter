using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    [SerializeField]
    private float shield;

    
    
    public void ShieldDamage(int damage)
    {
        shield -= damage;

        if (shield <= 0)
        {
            Destroy(this);
        }
    }
}
