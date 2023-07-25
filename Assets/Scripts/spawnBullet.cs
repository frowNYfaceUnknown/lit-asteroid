using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBullet : MonoBehaviour
{
    public GameObject spaceship;
    public GameObject bullet;
    public float coolDownTimer = 2f;
    private float timeElapsed = 0f;


    // returns the translated and rotated position for the bullet
    Vector3 getPos()
    {
        Vector3 offset = new Vector3(0.08f, 0.13f, -2f);
        Quaternion rotBy = Quaternion.AngleAxis(spaceship.transform.eulerAngles.z, Vector3.forward);
        Vector3 pos = rotBy * offset;
        return pos;
    }


    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (timeElapsed >= coolDownTimer)
            {
                Instantiate(bullet, getPos(), spaceship.transform.rotation);
                timeElapsed = 0f;
            }
        }
    }
}
