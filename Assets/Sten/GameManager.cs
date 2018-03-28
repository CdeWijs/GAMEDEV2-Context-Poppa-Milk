using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public EpisodeManager episodeManager;
    public AudioManager audioManager;
    public GameObject poppaMilk;
    public LevelTimer levelTimer;
    public ScoreTracker scoreTracker;

    public void Awake() {
        //Make this a Singleton because it has to be used by and be accessible to everything
        if(instance == null) {
            instance = this.gameObject.GetComponent<GameManager>();
        }else {
            Debug.Log("A game manager already exists");
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

	void Start () {
        //Call all start functions from the components
        this.episodeManager = this.GetComponent<EpisodeManager>();
        this.audioManager = this.GetComponent<AudioManager>();
        this.levelTimer = this.GetComponent<LevelTimer>();
        this.scoreTracker = this.GetComponent<ScoreTracker>();
        episodeManager.EpisodeInit();
        audioManager.AudioInit();
        GameManager.instance.episodeManager.CallEpisodeAudioAndSubs(Episode.Presentation);
        StartCoroutine(GameManager.instance.episodeManager.Talk(Speaker.Poppa, 3f));
        //Set starting screen settings
        levelTimer.SetupTimer(1f, 0.1f, false);
        scoreTracker.WipeScore();
        scoreTracker.ScoreVisibility(false);
        //episodeManager.CallEpisodeAudioAndSubs(Episode.Episode1);
        //episodeManager.NewEpisode(1);
        }

}
