using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Remanufacture_level : MonoBehaviour,ILevel {

    [SerializeField]
    private float timerDuration = 1;
    [SerializeField]
    private float subtractAmount = 0.1f; //The step the timer downgrades
    [SerializeField]
    private bool hasTimer = true;
    //Setup level with the correct lines
    void Start() {
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode2);
        StartCoroutine(GameManager.instance.episodeManager.Talk(Speaker.Poppa, 5f));
        GameManager.instance.levelTimer.SetupTimer(timerDuration, subtractAmount, hasTimer);
        GameManager.instance.levelTimer.currentLevel = this.gameObject;
        }

    void Update() { }

    public IEnumerator EndLevelSequence() {
        yield return new WaitForSeconds(1);
        StartCoroutine(GameManager.instance.episodeManager.EndCurrentEpisode());
        }
    }

/*
1 is de max (1.00F)
timer moet dus als max value 1.00F hebben
Stel 60 seconde
1/60 = de stapwaarde(?)
*/