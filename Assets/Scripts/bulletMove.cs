using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    public float speed = 20;
    public float xMax, xMin, yMax, yMin;
    private bool notWithinX, notWithinY;


    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;

        notWithinX = (transform.position.x > xMax) || (xMin > transform.position.x);
        notWithinY = (transform.position.y > yMax) || (yMin > transform.position.y);

        if (notWithinX || notWithinY) Destroy(gameObject);
    }
}
