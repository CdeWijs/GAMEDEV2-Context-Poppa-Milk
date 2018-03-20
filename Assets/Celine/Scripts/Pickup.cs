using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable {
    public GameObject sprite;
    public Product thisProduct; // declare in inspector
    public AchievementDatabase achievementDatabaseScript;

    private GameObject player;
    private PlayerController playerController;
    private ProductManager productManager;
    private InputSystem inputSystem;
    private List<Achievement> database;
    
    private bool clickable = false;

    [SerializeField]
    private float addDuration = 0.2f;

    [SerializeField]
    private bool leavePartsBehind = false;
    [SerializeField]
    private GameObject debris;

    private void Start() {
        // Get player controller for player check, and input system for multiplatform use
        playerController = FindObjectOfType<PlayerController>();
        player = playerController.gameObject;
        productManager = player.GetComponent<ProductManager>();
        inputSystem = playerController.inputSystem;

        // Get achievements
        //achievementDatabaseScript = FindObjectOfType<AchievementDatabase>();
        //database = achievementDatabaseScript.achievementDatabase;

        // Get blue circle and set inactive
        sprite.SetActive(false);
    }

    private void Update() {
        /*if (clickable)
        {
            if (inputSystem.GetColliderInteraction(collision2D, layerMask, this.name))
            {
                OnClick();
            }
        }*/
    }

    public void OnTriggerEnter(Collider collision) {
        Debug.Log("Collided");
        if (collision.GetComponentInParent<PlayerController>()) {
            sprite.SetActive(true);
            clickable = true;
            //collision2D = collision;
            Debug.Log("IN RANGE");
        }
    }

    private void OnTriggerExit(Collider collision) {
        if (collision.GetComponent<PlayerController>()) {
            sprite.SetActive(false);
            clickable = false;
        }
    }

    public void OnClick() {
        if (clickable) {
            // Unlock achievement and iterate to next one with variable from the achievementdatabase script
            //database[achievementDatabaseScript.index].isUnlocked = true;
            //achievementDatabaseScript.achievementPanel.UpdateList();
            //achievementDatabaseScript.index++;

            // Change product of player
            productManager.ChangeProduct(thisProduct);
            //GameManager.instance.levelTimer.AddToTimer(addDuration);
            SetInActive();
        }
    }

    private void SetInActive() {
        if (leavePartsBehind) {
            Instantiate(debris, this.transform.position, this.transform.rotation);
        }
        gameObject.SetActive(false);
    }
}
