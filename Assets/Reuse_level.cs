using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reuse_level : MonoBehaviour, ILevel {

    // Use this for initialization
    [SerializeField]
    private int levelDuration;


    void Start() {
        GameManager.instance.scoreTracker.ScoreVisibility(true);
        //GameManager.instance.levelTimer.SetupTimer(0, 0, false);
        GameManager.instance.levelTimer.SetupInvisibleTimer(levelDuration, 0.1f, true);
        GameManager.instance.levelTimer.currentLevel = this.gameObject;
        GameManager.instance.episodeManager.ResetLines();
        StartCoroutine(LevelDialogues());
    }

    // Update is called once per frame
    void Update() {

        }

    public IEnumerator EndLevelSequence() {
        yield return new WaitForSeconds(1);
        StartCoroutine(GameManager.instance.episodeManager.EndCurrentEpisode());
        }

    public IEnumerator LevelDialogues() {
        Debug.Log("started level 2");
        yield return new WaitForSeconds(2);
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode3);
        StartCoroutine(GameManager.instance.episodeManager.Talk(Speaker.Poppa, 5f));
        yield return new WaitForSeconds(5);
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode3);
        StartCoroutine(GameManager.instance.episodeManager.Talk(Speaker.Poppa, 8f));
        yield return new WaitForSeconds(8);
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode3);
        StartCoroutine(GameManager.instance.episodeManager.Talk(Speaker.Poppa, 5f));
    }
}
