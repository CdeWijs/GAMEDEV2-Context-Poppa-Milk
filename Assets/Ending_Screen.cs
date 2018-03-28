using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ending_Screen : MonoBehaviour {
    [SerializeField]
    private Text title;

	// Use this for initialization
	void Start () {
        PrintTitle();
	}

    // Update is called once per frame
    public void PrintTitle() {
        int score = GameManager.instance.scoreTracker.GetScore();
        
        if(score > 10) {
            title.text = "FOSSIL FUEL!";
        }
        else if( score > 50) {
            title.text = "AN ENERGY VAMPIRE!";
        }
        else if( score > 100) {
            title.text = "CARBON NEUTRAL!";
        }
        else if(score > 150) {
            title.text = "GREEN!";
        }
        else if(score > 200) {
            title.text = "RENEWABLE ENERGY!";
        }
        }
    


    public void PlayAgain() {
        SceneManager.LoadScene(0);
    }
}
