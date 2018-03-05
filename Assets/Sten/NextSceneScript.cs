using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextSceneScript : MonoBehaviour {

    public void NextEpisode(string scene) {
        SceneManager.LoadScene(scene);
        }
}
