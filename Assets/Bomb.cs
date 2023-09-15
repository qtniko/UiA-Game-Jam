using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;
    public float radius = 3f;
    public float delay = 2f;
    private void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Instantiate(explosion, transform.position,transform.rotation);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in colliders)
        {
            Destructable destructable = collider.GetComponent<Destructable>();
            if (destructable != null)
            {
                destructable.Unlive();
            }
        }
        
        Debug.Log("Boom!");
        
        Destroy(gameObject);
    }
}
