using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycle_level : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private float timerDuration = 1;
    [SerializeField]
    private float subtractAmount = 0.1f; //The step the timer downgrades
    [SerializeField]
    private bool hasTimer = true;
    //Setup level with the correct lines
    void Start() {
        GameManager.instance.episodeManager.ResetLines();
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode1);
        GameManager.instance.levelTimer.SetupTimer(timerDuration, subtractAmount, hasTimer);
        }
    // Update is called once per frame
    void Update () {
		
	}
}
