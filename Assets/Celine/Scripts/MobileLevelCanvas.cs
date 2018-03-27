using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileLevelCanvas : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        if (InputMobile.instance != null)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
