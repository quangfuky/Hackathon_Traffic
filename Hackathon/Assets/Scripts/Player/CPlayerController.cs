using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;// Required when using Event data.

public class CPlayerController : MonoBehaviour {
    public Transform currCar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(currCar ==null)
        {
            return;
        }
        else
        {
            CEnemyTest test = currCar.GetComponent<CEnemyTest>();
            if(test)
            {
                if(!test.isCatch) // bi bat hay chua
                {
                    if(test.isViolation) // co vi pham giao thong
                    {
                        ScoreManager.Instance.ScoreCatchGood++;
                    }
                    else
                    {
                        ScoreManager.Instance.ScorecatchFail++;
                    }
                    currCar.gameObject.SetActive(false);
                    currCar = null;
                }
            }
        }
	}

}
