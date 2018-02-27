using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public LayerMask layerMask;
    
    private GameObject sprite;
    private Collider2D collision2D = null;
    private bool clickable = false;

    public AchievementDatabase achievementDatabaseScript;
    private List<Achievement> database;

    public GameObject player; // declare in inspector
    private PlayerController playerController;
    private ProductManager productManager;
    private InputSystem inputSystem;
    
    private void Start()
    {
        // Get blue circle and set inactive
        sprite = transform.GetChild(0).gameObject;
        sprite.SetActive(false);

        // Get achievements
        achievementDatabaseScript = FindObjectOfType<AchievementDatabase>();
        database = achievementDatabaseScript.achievementDatabase;

        // Get player controller for player check, and input system for multiplatform use
        playerController = player.GetComponent<PlayerController>();
        productManager = player.GetComponent<ProductManager>();
        inputSystem = playerController.inputSystem;
    }

    private void Update()
    {
        // Check if player is inside pickup's collider
        if (clickable)
        {
            if (inputSystem.GetColliderInteraction(collision2D, layerMask, this.name))
            {
                OnClick();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Set blue circle active
        sprite.SetActive(true);

        // Player can click on pickup
        clickable = true;

        // Get collider and save to variable
        collision2D = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Set blue circle inactive
        sprite.SetActive(false);

        // Player can't click on pickup
        clickable = false;
    }

    // When player clicks on pickup
    public void OnClick()
    {
        // Make pickup disappear
        gameObject.SetActive(false);

        // Unlock achievement and iterate to next one with variable from the achievementdatabase script
        database[achievementDatabaseScript.index].isUnlocked = true;
        achievementDatabaseScript.achievementPanel.UpdateList();
        achievementDatabaseScript.index++;

        // Change product of player
        productManager.ChangeProduct();
        productManager.index++;
    }
}
