using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class testCar : MonoBehaviour
{
    public List<GameObject> listPoint;
    public int nextpoint;
	// Use this for initialization
	void Start ()
	{
	    transform.position = listPoint[0].transform.position;
	    nextpoint = 1;
	}
	
	// Update is called once per frame
	void Update () {
	    MoveCar();
	}

    public void MoveCar()
    {
        transform.position += transform.forward * Time.deltaTime * 3;
    }
    [ContextMenu("test")]
    public void Rotate()
    {
        Vector3 blue = transform.forward;
        float angle = Vector3.Angle(blue, (listPoint[1].transform.position - listPoint[2].transform.position));
        Debug.Log(angle);
        transform.rotation = Quaternion.AngleAxis(-angle, transform.up);
    }
}
