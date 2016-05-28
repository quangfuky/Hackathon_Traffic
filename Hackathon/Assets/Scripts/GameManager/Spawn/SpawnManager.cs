using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class SpawnManager : MonoBehaviour {
    [SerializeField]
    private int currCountCar = 0;
    [SerializeField]
    private int countCar = 5;

    public List<Transform> listPosition = new List<Transform>();
	// Use this for initialization
	void Start () {
	    
	}

    [ContextMenu("test")]
    public void SpawnGroupCar()
    {
        StartCoroutine(SpawnCarInDelay());
    }

    public IEnumerator SpawnCarInDelay()
    {
        while(true)
        {
            if(currCountCar >= countCar)
            {
                break;
            }
            GameObject objCar = ManagerObject.Instance.SpawnObjectByType(ObjectType.CAR_PREFABS);

            Transform pointSpawn = RandomPosition();
            if(pointSpawn)
            {
                objCar.transform.position = pointSpawn.position;
                CPointSpawn pointSpawnScript = pointSpawn.GetComponent<CPointSpawn>();
                if (pointSpawnScript)
                {
                    objCar.transform.eulerAngles = pointSpawnScript.forward;
                }
            }

            currCountCar++;
            yield return new WaitForSeconds(Random.Range(2f,4f));
        }
    }
	
    public Transform RandomPosition()
    {
        int _index = Random.Range(0,listPosition.Count);
        //Debug.Log(_index);
        return listPosition[_index];
    }
	// Update is called once per frame
	void Update () {
	
	}
}
