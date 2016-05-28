using UnityEngine;
using System.Collections;

public class ScoreManager : MonoSingleton<ScoreManager> {
    [SerializeField]
    private int scoreCatchGood = 0;
    public int ScoreCatchGood
    {
        get { return scoreCatchGood; }
        set { scoreCatchGood = value; }
    }
    [SerializeField]
    private int scorecatchFail = 0;

    public int ScorecatchFail
    {
        get { return scorecatchFail; }
        set { scorecatchFail = value; }
    }
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
