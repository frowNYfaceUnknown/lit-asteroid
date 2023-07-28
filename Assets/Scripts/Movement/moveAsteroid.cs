using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAsteroid : MonoBehaviour
{
    public float velocity = 5f;
    public Rigidbody2D rb2d;


    void setVel()
    {
        rb2d.velocity = velocity * (-transform.position).normalized;
    }


    // Start is called before the first frame update
    void Start()
    {
        setVel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
