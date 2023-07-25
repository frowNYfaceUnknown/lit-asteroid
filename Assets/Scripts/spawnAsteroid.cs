using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAsteroid : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject asteroidPrefab;

    [SerializeField] private float xMax, xMin, yMax, yMin;

    public float spawnRate = 1f;
    private float timeElapsed = 0f;


    private bool thisOverThat { get { return Random.Range(0, 2) == 1; } }

    void spawnX()
    {
        int chosenSprite = Random.Range(0, sprites.Length);
        float chosenX = thisOverThat ? xMax : xMin;
        float yPosition = Random.Range(yMin, yMax);
        GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(chosenX, yPosition, 0), transform.rotation);
        asteroid.GetComponent<SpriteRenderer>().sprite = sprites[chosenSprite];
    }


    void spawnY()
    {
        int chosenSprite = Random.Range(0, sprites.Length);
        float chosenY = thisOverThat ? yMax : yMin;
        float xPosition = Random.Range(xMin, xMax);
        GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(xPosition, chosenY, 0), transform.rotation);
        asteroid.GetComponent<SpriteRenderer>().sprite = sprites[chosenSprite];
    }


    void spawn() { if (thisOverThat) { spawnX(); } else { spawnY(); } }


    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }


    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > spawnRate)
        {
            spawn();
            timeElapsed = 0f;
        }
    }
}
