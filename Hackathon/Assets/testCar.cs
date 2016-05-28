using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class testCar : MonoBehaviour
{
    public List<GameObject> listPoint;
    public int nextpoint;
    public Transform head;
	// Use this for initialization
	void Start ()
	{
	    transform.position = listPoint[0].transform.position;
	    nextpoint = 1;
    }
	
	// Update is called once per frame
	void Update () {
	    //MoveCar();
        //Rotate();
	}

    public void MoveCar()
    {
        transform.position -= transform.forward * Time.deltaTime * 3;
    }
    public void Rotate()
    {
        if ((transform.position - listPoint[nextpoint].transform.position).magnitude < 0.15)
        {
            
        }
        
    }

    [ContextMenu("test")]
    public void Test()
    {
        Vector3 blue = transform.forward;
        Vector3 temp = head.position - transform.position;
        Debug.Log(Vector3.Angle(blue, temp));
    }
}
