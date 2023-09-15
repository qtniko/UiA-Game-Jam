using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpBomb : MonoBehaviour
{
    public GameObject pickupEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
            collision.GetComponent<BombAbility>().enabled = true;
            Destroy(gameObject);
        }
    }

    
}
