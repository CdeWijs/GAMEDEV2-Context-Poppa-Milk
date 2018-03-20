using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reuse_level : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private int levelDuration;
    void Start() {
        GameManager.instance.scoreTracker.ScoreVisibility(true);
        //GameManager.instance.levelTimer.SetupTimer(0, 0, false);
        GameManager.instance.levelTimer.SetupInvisibleTimer(levelDuration, 0.1f, true);
        GameManager.instance.episodeManager.ResetLines();
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode3);
        }

    // Update is called once per frame
    void Update() {

        }
    }
