using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour {
    private CPlayerController playerController;
	// Use this for initialization
	void Awake () {
        playerController = FindObjectOfType(typeof(CPlayerController)) as CPlayerController;
	}
    void OnMouseDown()
    {
        if(playerController)
        {
            playerController.currCar = this.gameObject.transform;
        }
    }
}
