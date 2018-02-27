using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Episode {Episode1, Episode2, Episode3,Presentation};

public class EpisodeManager : MonoBehaviour {
    //Two components needed to create narrative
    private AudioManager audioManager;
    private TextReader textReader;

    //Lists to store each text per episode
    private List<string> episode1Lines = new List<string>();
    private List<string> episode2Lines = new List<string>();
    private List<string> episode3Lines = new List<string>();

    //UI elements
    [SerializeField]
    private Text subtitleTrack;

    //Level variables
    public bool passedCheckpoint = false;
    [SerializeField]
    private bool next = false;
    private int currentTextLine = 0;
    private int currentAudioLine = 0;
    private int currentEpisode = 0;

    //Everything for the presentation
    private List<string> presentationLines = new List<string>();
    private int stage = 0;

    //Episode 1 = reuse
    //Episode 2 = remanufacture
    //Episdoe 3 = recycle

    //Solid init to be called on reset for example
    //Assign variables

   public void Update() {
    }

    public void EpisodeInit() {
        audioManager = this.GetComponent<AudioManager>();
        textReader = this.GetComponent<TextReader>();
        //Load all lists with the strings from text files
        textReader.Load(Episode.Episode1.ToString(), episode1Lines);
        textReader.Load(Episode.Episode2.ToString(), episode2Lines);
        textReader.Load(Episode.Episode3.ToString(), episode3Lines);
        textReader.Load(Episode.Presentation.ToString(),presentationLines);
        //StartCoroutine(EpisodeHandler(Episode.Episode1));
    }

    public int NewEpisode(int ep) {
        currentAudioLine = 0;
        currentTextLine = 0;
        currentEpisode = ep;
        return currentEpisode;
    }
    
    public void CallEpisodeAudioAndSubs(Episode ep) {
        StartCoroutine(EpisodeHandler(ep));
    }

    private IEnumerator CheckIfTalking(Episode ep) {
        Debug.Log("still playing");
        yield return new WaitWhile(()=>audioManager.PoppaMilk.isPlaying);
        //yield return new WaitUntil(() => audioManager.PoppaMilk.isPlaying);
        Debug.Log("no longer playing");
        next = true;
        stage++;
    }

    private IEnumerator EpisodeHandler(Episode ep) {
        //Play current state audio and set subtitles
        switch (ep) {
            case Episode.Episode1:
                GameManager.instance.poppaMilk.GetComponent<Animator>().SetBool("isTalking", true);
                subtitleTrack.text = episode1Lines[currentTextLine];
                audioManager.PlayPoppaMilk(currentAudioLine, ep);
                break;
            case Episode.Episode2:
                GameManager.instance.poppaMilk.GetComponent<Animator>().SetBool("isTalking", true);
                subtitleTrack.text = episode2Lines[currentTextLine];
                audioManager.PlayPoppaMilk(currentAudioLine, ep);
                break;
            case Episode.Episode3:
                GameManager.instance.poppaMilk.GetComponent<Animator>().SetBool("isTalking", true);
                subtitleTrack.text = episode3Lines[currentTextLine];
                audioManager.PlayPoppaMilk(currentAudioLine, ep);
                break;
            case Episode.Presentation:
                GameManager.instance.poppaMilk.GetComponent<Animator>().SetBool("isTalking", true);
                Debug.Log(GameManager.instance.poppaMilk.GetComponent<Animator>().GetBool("isTalking"));
                subtitleTrack.text = presentationLines[currentTextLine];
                audioManager.PlayPoppaMilk(currentAudioLine, ep);
                break;
        }

        //Wait until checkpoint is passed to proceed
        StartCoroutine(CheckIfTalking(ep));
        //CheckIfTalking(ep);
        yield return new WaitUntil(() => next);
        switch (ep) {
            case Episode.Episode1:
                if (currentTextLine < episode1Lines.Count - 1) {
                    currentAudioLine++;
                    currentTextLine++;
                    Debug.Log("next: " + currentTextLine);
                    next = false;
                }
                else {
                    currentTextLine = 0;
                    currentAudioLine = 0;
                    stage = 0;
                }
                break;

            case Episode.Episode2:
                if (currentTextLine < episode2Lines.Count - 1) {
                    currentAudioLine++;
                    currentTextLine++;
                    Debug.Log("next: " + currentTextLine);
                    next = false;
                }
                else {
                    currentTextLine = 0;
                    currentAudioLine = 0;
                    stage = 0;
                    next = false;
                }
                break;

            case Episode.Episode3:
                if (currentTextLine < episode3Lines.Count -1) {
                    currentAudioLine++;
                    currentTextLine++;
                    Debug.Log("next: " + currentTextLine);
                    next = false;
                }
                else {
                    currentTextLine = 0;
                    currentAudioLine = 0;
                    stage = 0;
                    next = false;
                }
                break;

            case Episode.Presentation:
                if(currentTextLine < presentationLines.Count -1) {
                    currentAudioLine++;
                    currentTextLine++;
                    Debug.Log("next: " + currentTextLine);
                    next = false;
                    GameManager.instance.poppaMilk.GetComponent<Animator>().SetBool("isTalking", false);
                }
                else {
                    currentTextLine = 0;
                    currentAudioLine = 0;
                    stage = 0;
                    next = false;
                }
                break;
        }

    }

    public void ProceedInDialogue(Episode ep) {
        StartCoroutine(EpisodeHandler(ep));
    }
}
