using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrafficLight : MonoBehaviour
{
    public List<GameObject> redLight;
    public List<GameObject> greenLight;

    public List<CheckPoint> checkPoint; 


    public float lightTime;
    public int lightIndex;

    // Use this for initialization
    void Start()
    {
        lightTime = Random.Range(5, 10);
        Change();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeLight();
    }

    public void ChangeLight()
    {
        if (lightTime > 0)
        {
            lightTime -= Time.deltaTime;
        }
        else
        {
            lightTime = Random.Range(5, 10);
            Change();
        }
    }

    public void Change()
    {
        for (int index = 0; index < greenLight.Count; index++)
        {
            var green = greenLight[index];
            green.SetActive(index % 2 == lightIndex);
            checkPoint[index].canGo = index%2 == lightIndex;
        }

        for (int index = 0; index < redLight.Count; index++)
        {
            var red = redLight[index];
            red.SetActive(index % 2 != lightIndex);
        }
        lightIndex = lightIndex == 1 ? 0 : 1;
    }
}
