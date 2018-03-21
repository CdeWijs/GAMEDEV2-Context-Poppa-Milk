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

    public void StartGame() {
        StartCoroutine(KickOff());
        }

    public IEnumerator KickOff() {
        GameManager.instance.episodeManager.ResetLines();
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode1);
        Debug.Log("1");
        yield return new WaitForSeconds(5);
        Debug.Log("2");
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode1);
        yield return new WaitForSeconds(5);
        GameManager.instance.episodeManager.FirstEpisode();
        }
}
