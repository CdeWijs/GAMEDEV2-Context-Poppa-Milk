using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollowPoppa : MonoBehaviour {


    //STAY IN CAMERA FIELD, FOLLOW MILKY BOY IN THE BACKGROUND
    //ANIMATIONS LINKED

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += ChangeSize;
    }

    private void Start()
    {
        transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
    }

    private void ChangeSize(Scene prevScene, Scene currentScene)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
