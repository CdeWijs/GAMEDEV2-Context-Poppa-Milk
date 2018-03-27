using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    public Product thisProduct; // declare in inspector
    public AchievementDatabase achievementDatabaseScript;
    public GameObject particleEffect;

    private GameObject player;
    private PlayerController playerController;
    private InputSystem inputSystem;

    private ProductManager productManager;
    private List<Achievement> database;
    
    private bool clickable = false;
    private GameObject sprite;

    [SerializeField]
    private float addDuration = 0.2f;

    [SerializeField]
    private bool leavePartsBehind = false;
    [SerializeField]
    private GameObject debris;

    private void Start()
    {
        // Get player controller for player check, and input system for multiplatform use
        playerController = FindObjectOfType<PlayerController>();
        player = playerController.gameObject;
        inputSystem = playerController.inputSystem;

        productManager = player.GetComponent<ProductManager>();

        // Get blue circle and set inactive
        sprite = transform.GetChild(0).gameObject;
        sprite.SetActive(false);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponentInParent<PlayerController>())
        {
            sprite.SetActive(true);
            clickable = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            sprite.SetActive(false);
            clickable = false;
        }
    }

    public void OnClick()
    {
        if (clickable)
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 1f, -2f);
            GameObject particles = Instantiate(particleEffect, position, Quaternion.identity) as GameObject;

            // Change product of player
            productManager.ChangeProduct(thisProduct);

            //GameManager.instance.levelTimer.AddToTimer(addDuration);
            SetInActive();
        }
    }

    private void SetInActive()
    {
        if (leavePartsBehind)
        {
            Instantiate(debris, this.transform.position, this.transform.rotation);
        }
        gameObject.SetActive(false);
    }
}
