using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Episode {Episode1, Episode2, Episode3,Episode4,Presentation};

public class EpisodeManager : MonoBehaviour {
    //Two components needed to create narrative
    private AudioManager audioManager;
    private TextReader textReader;

    //Lists to store each text per episode
    private List<string> episode1Lines = new List<string>();
    private List<string> episode2Lines = new List<string>();
    private List<string> episode3Lines = new List<string>();
    private List<string> episode4Lines = new List<string>();

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

    //Save poppa's animator to access easily
    private Animator poppaAnimator;
    //Everything for the presentation
    private List<string> presentationLines = new List<string>();
    private int stage = 0;

    //Solid init to be called on reset for example
    public void EpisodeInit() {
        audioManager = this.GetComponent<AudioManager>();
        textReader = this.GetComponent<TextReader>();
        poppaAnimator = GameManager.instance.poppaMilk.GetComponent<Animator>();
        //Load all lists with the strings from text files
        textReader.Load(Episode.Episode1.ToString(), episode1Lines);
        textReader.Load(Episode.Episode2.ToString(), episode2Lines);
        textReader.Load(Episode.Episode3.ToString(), episode3Lines);
        textReader.Load(Episode.Episode4.ToString(), episode4Lines);
        textReader.Load(Episode.Presentation.ToString(),presentationLines);
    }
    //Start the game!
    public void FirstEpisode() {
        NewEpisode(1);
        }

    //function to setup everything for a new episode including changing the scene
    public int NewEpisode(int ep) {
        //currentAudioLine = 0;
        //currentTextLine = 0;
        currentEpisode = ep;
        SceneManager.LoadScene(ep);
        return currentEpisode;
    }

    //Function to end the current episode, show some text let poppa say something and then start the next episode
    public IEnumerator EndCurrentEpisode() {
        Debug.Log("initiating countdown");
        yield return new WaitForSeconds(5f);
        NewEpisode(currentEpisode +=1);
        Debug.Log("next scene: " + currentEpisode);
        }

    //Easy way to call the audio and subs function, if called proceeds to the next line and audio
    public void CallEpisodeAudioAndSubs(Episode ep) {
        StartCoroutine(EpisodeHandler(ep));
    }

    //This returns true if poppa is still talking, return new int for the next line upon completion
    private IEnumerator CheckIfTalking(Episode ep) {
        //Debug.Log("still playing");
        yield return new WaitWhile(()=>audioManager.PoppaMilk.isPlaying);
        //Debug.Log("no longer playing");
        next = true;
        stage++;
    }

    //Actually play the audio and show the subtitles
    private IEnumerator EpisodeHandler(Episode ep) {
        //Play current state audio and set subtitles
        switch (ep) {
            case Episode.Episode1:
                poppaAnimator.SetBool("isTalking", true);
                subtitleTrack.text = episode1Lines[currentTextLine];
                audioManager.PlayPoppaMilk(currentAudioLine, ep);
                break;
            case Episode.Episode2:
                poppaAnimator.SetBool("isTalking", true);
                subtitleTrack.text = episode2Lines[currentTextLine];
                audioManager.PlayPoppaMilk(currentAudioLine, ep);
                break;
            case Episode.Episode3:
                poppaAnimator.SetBool("isTalking", true);
                subtitleTrack.text = episode3Lines[currentTextLine];
                audioManager.PlayPoppaMilk(currentAudioLine, ep);
                break;
            case Episode.Episode4:
                poppaAnimator.SetBool("isTalking", true);
                subtitleTrack.text = episode4Lines[currentTextLine];
                audioManager.PlayPoppaMilk(currentAudioLine, ep);
                break;
            case Episode.Presentation:
                poppaAnimator.SetBool("isTalking", true);
                //Debug.Log(GameManager.instance.poppaMilk.GetComponent<Animator>().GetBool("isTalking"));
                subtitleTrack.text = presentationLines[currentTextLine];
                audioManager.PlayPoppaMilk(currentAudioLine, ep);
                break;
        }

        //Wait until checkpoint is passed to proceed, set all values to the next line!
        StartCoroutine(CheckIfTalking(ep));
        yield return new WaitUntil(() => next);
        switch (ep) {
            case Episode.Episode1:
                if (currentTextLine < episode1Lines.Count - 1) {
                    currentAudioLine++;
                    currentTextLine++;
                    Debug.Log("next: " + currentTextLine);
                    next = false;
                    poppaAnimator.SetBool("isTalking", false);
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
                    poppaAnimator.SetBool("isTalking", false);
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
                    poppaAnimator.SetBool("isTalking", false);
                    }
                else {
                    currentTextLine = 0;
                    currentAudioLine = 0;
                    stage = 0;
                    next = false;
                }
                break;

            case Episode.Episode4:
                if (currentTextLine < episode4Lines.Count - 1) {
                    currentAudioLine++;
                    currentTextLine++;
                    Debug.Log("next: " + currentTextLine);
                    next = false;
                    poppaAnimator.SetBool("isTalking", false);
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
                    next = false;
                    poppaAnimator.SetBool("isTalking", false);
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

    //Reset everything to a brand new episode
    public void ResetLines() {
        currentTextLine = 0;
        currentAudioLine = 0;
        stage = 0;
        next = false;
        }

    public int GetEpisode() {
        return currentEpisode;
        }
}
