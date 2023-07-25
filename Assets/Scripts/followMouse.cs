using UnityEngine;

public class followMouse : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2d;


    // transforms euler angles into a local coordinate based
    // vector that points in the direction of the euler angle
    Vector3 getVecFromAngle(Vector3 eAngle)
    {
        float posComponent = eAngle.z;
        Vector3 vector = new Vector3(-Mathf.Sin(Mathf.Deg2Rad * posComponent), Mathf.Cos(Mathf.Deg2Rad * posComponent), 0);

        // Debug Only
        // Debug.DrawRay(new Vector3(0, 0, 0), vector);

        return vector;
    }


    Vector3 toWorldPos(Vector3 mousePos)
    {
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        // Debug only
        // mousePos = mousePos.normalized;
        // Debug.DrawRay(new Vector3(0, 0, 0), mousePos);

        return mousePos;
    }


    float posToDeg(Vector3 startPos, Vector3 endPos)
    {
        // SignedAngle is used over Angle to know in which direction to rotate
        return Vector3.SignedAngle(startPos, endPos, Vector3.forward);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 spaceShipDir = getVecFromAngle(transform.eulerAngles);
        Vector3 mouseDir = toWorldPos(Input.mousePosition);
        float power = posToDeg(spaceShipDir, mouseDir);
        rb2d.AddTorque(power * Time.fixedDeltaTime);
    }
}
