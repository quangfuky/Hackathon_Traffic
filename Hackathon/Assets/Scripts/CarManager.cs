using UnityEngine;
using System.Collections;

public enum CarStage
{
    VIPHAM,
    MOVE
}

public enum CarDirect
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public class CarManager : MonoBehaviour
{
    public float speed;
    public Vector3 speedMove;

    public float rotation;
    public float speedRotation;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       MoveObject();
    }
    [ContextMenu("test")]
    public void Move()
    {
        Debug.Log(transform.right);
        transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
    }

    public void MoveObject()
    {
        //rotation += speedRotation * Time.deltaTime;
        //transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z));
        // move
        transform.position -= transform.forward*Time.deltaTime*speed;
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collise");
        if (col.tag == "CheckPoint")
        {
            speed = 0;
            Debug.Log("Collise");
        }
    }
}
