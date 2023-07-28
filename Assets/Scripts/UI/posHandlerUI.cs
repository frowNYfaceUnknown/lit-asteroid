using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posHandlerUI : MonoBehaviour
{
    private Vector3 defaultPos;

    private void hover(Vector3 defaultPos, float offset, int vel = 50)
    {
        transform.position = new Vector3(defaultPos.x, defaultPos.y + Mathf.Sin(offset) * vel, defaultPos.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hover(defaultPos, Time.time);
    }
}
