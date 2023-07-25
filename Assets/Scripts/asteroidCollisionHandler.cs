using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidCollisionHandler : MonoBehaviour
{
    private int health;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedWith = collision.gameObject;

        if (collidedWith.tag == "Short Bullet") --health;

        else if (collidedWith.tag == "Long Bullet") health -= 2; // left to implement for now

        else if (collidedWith.tag == "Player")
        {
            Rigidbody2D rb2d = collidedWith.GetComponent<Rigidbody2D>();
            rb2d.constraints = RigidbodyConstraints2D.None;
        }

        Destroy(collidedWith);

        if (health <= 0) Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
