using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartScreen : MonoBehaviour {

    TextReader txtReader = new TextReader();
    private List<string> randomFacts = new List<string>();
    [SerializeField]
    private Text factsUI;

	// Use this for initialization
	void Start () {
        txtReader.Load("StartScreen", randomFacts);
        factsUI.text = randomFacts[Random.Range(0, randomFacts.Count)];
	}
}
