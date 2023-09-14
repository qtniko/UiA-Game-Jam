using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int health = 3;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) { Die(); }
    }
    public void Die()
    {
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        gameObject.GetComponent<movement>().enabled = false;
        //send game over screen
        Debug.Log("U ded");

    }
}
