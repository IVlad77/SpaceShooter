using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{


    Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            Destroy(gameObject);
            
            
        }

          
    }



}
