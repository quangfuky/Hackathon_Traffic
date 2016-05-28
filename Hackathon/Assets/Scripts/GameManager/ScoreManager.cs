using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    public Text txtGoodScore;
    public Text txtFailScore;

	// Use this for initialization
	void Start () {
	    
	}

    public void UpdateShowGoodScore()
    {
        txtGoodScore.text = ScoreCatchGood.ToString();
    }

    public void UpdateShowFailScore()
    {
        txtFailScore.text = ScorecatchFail.ToString();
    }

	// Update is called once per frame
	void Update () {
        UpdateShowGoodScore();
        UpdateShowFailScore();
	}
}
