using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartScreen : MonoBehaviour
{
    public GameObject startButton;

    TextReader txtReader = new TextReader();
    private List<string> randomFacts = new List<string>();
    [SerializeField]
    private Text factsUI;

	// Use this for initialization
	void Start ()
    {
        txtReader.Load("StartScreen", randomFacts);
        factsUI.text = randomFacts[Random.Range(0, randomFacts.Count)];
	}

    public void StartGame()
    {
        // Set strat button to inactive, so the player stops pressing it.
        startButton.SetActive(false);
        StartCoroutine(KickOff());
    }

    public IEnumerator KickOff()
    {
        GameManager.instance.episodeManager.ResetLines();
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode1);
        StartCoroutine(GameManager.instance.episodeManager.Talk(Speaker.Poppa, 5f));
        yield return new WaitForSeconds(5);

        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Episode1);
        StartCoroutine(GameManager.instance.episodeManager.Talk(Speaker.Soyboy, 5f));
        yield return new WaitForSeconds(5);

        GameManager.instance.episodeManager.FirstEpisode();
    }
}
