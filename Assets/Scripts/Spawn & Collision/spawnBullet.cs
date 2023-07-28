using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBullet : MonoBehaviour
{
    public GameObject spaceship;
    public GameObject bulletPrefab;
    public Sprite shortBullet;
    public Sprite longBullet;
    [SerializeField] private float coolDownTimer = 2f;
    [SerializeField] private float mouseTimer = 1f;
    private float timeElapsed = 0f;
    private float mouseTimeElapsed = 0f;


    // returns the translated and rotated position for the bullet
    Vector3 getPos()
    {
        Vector3 offset = new Vector3(0.08f, 0.13f, -2f);
        Quaternion rotBy = Quaternion.AngleAxis(spaceship.transform.eulerAngles.z, Vector3.forward);
        Vector3 pos = rotBy * offset;
        return pos;
    }


    // Start is called before the first frame update
    void Start()
    {
        EventHandler.OnPlayerDeath += disableScript;
    }


    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (Input.GetMouseButton(0)) mouseTimeElapsed += Time.deltaTime;

        if (Input.GetMouseButtonUp(0))
        {
            if (mouseTimeElapsed >= mouseTimer)
            {
                GameObject bullet = Instantiate(bulletPrefab, getPos(), spaceship.transform.rotation);
                bullet.tag = "Long Bullet";
                bullet.GetComponent<SpriteRenderer>().sprite = longBullet;
                mouseTimeElapsed = 0f;
            }
            else if (timeElapsed >= coolDownTimer)
            {
                GameObject bullet = Instantiate(bulletPrefab, getPos(), spaceship.transform.rotation);
                bullet.tag = "Short Bullet";
                bullet.GetComponent<SpriteRenderer>().sprite = shortBullet;
                timeElapsed = 0f;
            }
        }
    }


    public void disableScript()
    {
        this.enabled = false;
    }

    private void OnDestroy()
    {
        EventHandler.OnPlayerDeath -= disableScript;
    }
}
