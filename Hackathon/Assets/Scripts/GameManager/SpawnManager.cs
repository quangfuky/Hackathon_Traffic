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
            objCar.transform.position = RandomPosition();

            currCountCar++;
            yield return new WaitForSeconds(Random.Range(2f,4f));
        }
    }
	
    public Vector3 RandomPosition()
    {
        int _index = Random.Range(0,listPosition.Count);
        return listPosition[_index].position;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
