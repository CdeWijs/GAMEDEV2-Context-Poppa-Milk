using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelTimer : MonoBehaviour {

    [SerializeField]
    private Text timerChange;//Maybe use this to add some flavor?
    public Slider timer;//The visual representation of this timer, and with that the duration to be in game
    [SerializeField]
    private float timerCurrent = 1;
    private float currentTimer = 0;
    private float executeSpeed = 1; //time between executions
    public float subtractAmount = 0.1f; //The step the timer downgrades
    private bool endingCalled = false; // make sure to only call the ending of the level once
    private bool isActive = false;

    //A simple timer
    void Update() {
        if (!endingCalled && isActive) {
            if (timerCurrent > 0) {
                if (currentTimer >= executeSpeed) {
                    //Do action
                    timerCurrent -= subtractAmount;
                    timer.value = Mathf.Clamp(timerCurrent, 0, 1);
                    currentTimer = 0;

                    }
                else {
                    timer.value = Mathf.Clamp(timerCurrent, 0, 1);
                    currentTimer += Time.deltaTime;
                    }
                }
            else {
                //level done
                StartCoroutine(GameManager.instance.episodeManager.EndCurrentEpisode());
                Debug.Log("called ending");
                endingCalled = true;
                }
            }

        }

    public void SetupTimer(float max, float _subtractAmount, bool active) {
        timerCurrent = max;
        subtractAmount = _subtractAmount;
        isActive = active;
        timer.gameObject.SetActive(active);
        endingCalled = false;
        }

    public void SetupInvisibleTimer(float max, float _subtractAmount, bool active) {
        timerCurrent = max;
        subtractAmount = _subtractAmount;
        isActive = active;
        timer.gameObject.SetActive(false);
        endingCalled = false;
        }

    //Function to add time to extend the longelivety of this level
    public float AddToTimer(float amount) {
        timerCurrent += amount;
        Mathf.Clamp(timerCurrent, 0, 1f);
        return timerCurrent;
        }
    }

