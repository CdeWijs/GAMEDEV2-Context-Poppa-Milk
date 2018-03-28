using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreTracker : MonoBehaviour {

    private int score;
    [SerializeField]
    private Text scoreField;

    public int UpdateScore(int variable) {
        score += variable;
        scoreField.text = score.ToString();
        return score;
        }
    public int WipeScore() {
        score = 0;
        scoreField.text = score.ToString();
        return score;
        }

    public void ScoreVisibility(bool active) {
        scoreField.gameObject.SetActive(active);
        scoreField.text = score.ToString();
        }

    public int GetScore() {
        return score;
    }
}
