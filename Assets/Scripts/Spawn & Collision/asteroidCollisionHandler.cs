using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class asteroidCollisionHandler : MonoBehaviour
{
    private int health;
    public EventHandler eventHandler;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedWith = collision.gameObject;

        if (collidedWith.tag == "Short Bullet")
        {
            --health; Destroy(collidedWith);
        }

        else if (collidedWith.tag == "Long Bullet")
        {
            health -= 3; Destroy(collidedWith);
        }

        else if (collidedWith.tag == "Player")
        {
            Rigidbody2D rb2d = collidedWith.GetComponent<Rigidbody2D>();
            rb2d.constraints = RigidbodyConstraints2D.None;
            eventHandler.TriggerOnPlayerDeath();
        }

        if (health <= 0)
        {
            eventHandler.TriggerOnBulletHit();
            Destroy(gameObject);
        }
    }


    void Awake()
    {
        GameObject obj = GameObject.FindWithTag("Event Manager");
        eventHandler = obj.GetComponent<EventHandler>();
    }


    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
