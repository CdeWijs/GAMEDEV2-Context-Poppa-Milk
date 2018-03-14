using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycle_level : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.instance.scoreTracker.ScoreVisibility(true);
        //GameManager.instance.levelTimer.SetupTimer(0, 0, false);
        GameManager.instance.levelTimer.SetupInvisibleTimer(1, 0.1f, true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
