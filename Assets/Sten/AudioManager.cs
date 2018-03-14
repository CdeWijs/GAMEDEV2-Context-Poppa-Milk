using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoppaMilk{Scenario1,Scenario2,Scenario3};
public enum InteractableSound {PickupSound};
public enum PlayerSound {DieSound};


public class AudioManager : MonoBehaviour {
    [SerializeField]
    public AudioSource PoppaMilk;
    [SerializeField]
    private AudioClip[] poppaEpisode1;
    [SerializeField]
    private AudioClip[] poppaEpisode2;
    [SerializeField]
    private AudioClip[] poppaEpisode3;
    [SerializeField]
    private AudioClip[] presentation;

    [SerializeField]
    private AudioSource interactableSource1;
    [SerializeField]
    private AudioSource interactableSource2;
    [SerializeField]
    private AudioSource interactableSource3;
    [SerializeField]
    private AudioClip[] interactableSounds;

    public void AudioInit() {
        
    }

    //All audio that poppa milk is involved in
    public AudioSource PlayPoppaMilk(int sound, Episode ep) {
        if (PoppaMilk.isPlaying) {
            StartCoroutine(QueuePoppaMilk(sound, ep));
        }
        else {
            switch (ep) {
                case Episode.Episode1:
                    Debug.Log("Playing sound ep1");
                    PoppaMilk.clip = poppaEpisode1[sound];
                    PoppaMilk.Play();
                    break;

                case Episode.Episode2:
                    Debug.Log("Playing sound ep2");
                    PoppaMilk.clip = poppaEpisode2[sound];
                    PoppaMilk.Play();
                    break;

                case Episode.Episode3:
                    Debug.Log("Playing sound ep3");
                    PoppaMilk.clip = poppaEpisode3[sound];
                    PoppaMilk.Play();
                    break;

                case Episode.Presentation:
                    //Debug.Log("playing sound presentation");
                    PoppaMilk.clip = presentation[sound];
                    PoppaMilk.Play();
                    break;
            }
        }
        return PoppaMilk;
    }

    public bool CheckPoppaPlaying() {
        return PoppaMilk.isPlaying;
    }

    private IEnumerator QueuePoppaMilk(int sound, Episode ep) {
        //Debug.Log("Queued");
        yield return new WaitWhile(() => PoppaMilk.isPlaying);
        switch (ep) {
            case Episode.Episode1:
                PoppaMilk.clip = poppaEpisode1[sound];
                PoppaMilk.Play();
                break;

            case Episode.Episode2:
                PoppaMilk.clip = poppaEpisode2[sound];
                PoppaMilk.Play();
                break;

            case Episode.Episode3:
                PoppaMilk.clip = poppaEpisode3[sound];
                PoppaMilk.Play();
                break;
            case Episode.Presentation:
                PoppaMilk.clip = presentation[sound];
                PoppaMilk.Play();
                break;
        }
        //Debug.Log("unloaded");
    }

    //Play sounds that have to do with interactions, 3 sounds can play at once
    public AudioSource PlayInteractableSound(InteractableSound sound) {
        AudioClip clip = interactableSounds[(int)sound];
        if (interactableSource1.isPlaying) {
            //load new clip and play audiosource 1
            interactableSource1.clip = clip;
            interactableSource1.Play();
            return interactableSource1;

        }else if(interactableSource2.isPlaying){
            //load new clip and play audiosource 2
            interactableSource2.clip = clip;
            interactableSource2.Play();
            return interactableSource2;

        }else {
            //load new clip and play audiosource 3
            interactableSource3.clip = clip;
            interactableSource3.Play();
            return interactableSource3;
        }       
    }	
}
