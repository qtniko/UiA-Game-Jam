using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    Rigidbody2D rb2d;
    float moveHor;
    [SerializeField] private float speed = 100f;
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        moveHor = Input.GetAxisRaw("Horizontal");

    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector2 dir;
        
        rb2d.velocity = new Vector2(moveHor* speed * Time.deltaTime , rb2d.velocity.y);
    }
}
