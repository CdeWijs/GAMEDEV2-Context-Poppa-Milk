using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presentation : MonoBehaviour {

    public List<GameObject> slides = new List<GameObject>();
    private int currentSlide = 0;
	// Use this for initialization
	void Start () {

	}
	
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Next();
        }
        if (Input.GetMouseButtonDown(1)) {
            NextSlide();
        }
    }

	public void Next() {
        Debug.Log("Next");
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Presentation);
        //GameManager.instance.episodeManager.ProceedInDialogue(Episode.Presentation);

    }
    public void NextSlide() {
        if (currentSlide != 0) {
            slides[currentSlide].SetActive(true);
            slides[currentSlide - 1].SetActive(false);
        }        
        else {
            slides[currentSlide].SetActive(true);

        }

        if (currentSlide != slides.Count-1) {
            currentSlide++;
        }
        else { slides[currentSlide].SetActive(false); currentSlide = 0; }

    }
}
