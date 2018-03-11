using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject sprite;
    public LayerMask layerMask; // player
    public AchievementDatabase achievementDatabaseScript;

    private GameObject player;
    private PlayerController playerController;
    private ProductManager productManager;
    private InputSystem inputSystem;
    private List<Achievement> database;

    private Collider2D collision2D = null;
    private bool clickable = false;
    
    private void Start()
    {
        // Get player controller for player check, and input system for multiplatform use
        playerController = FindObjectOfType<PlayerController>();
        player = playerController.gameObject;
        productManager = player.GetComponent<ProductManager>();
        inputSystem = playerController.inputSystem;

        // Get achievements
        achievementDatabaseScript = FindObjectOfType<AchievementDatabase>();
        database = achievementDatabaseScript.achievementDatabase;

        // Get blue circle and set inactive
        sprite.SetActive(false);
    }

    private void Update()
    {
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
        if (collision.GetComponent<PlayerController>())
        {
            sprite.SetActive(true);
            clickable = true;
            collision2D = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            sprite.SetActive(false);
            clickable = false;
        }
    }
    
    public void OnClick()
    {
        // Unlock achievement and iterate to next one with variable from the achievementdatabase script
        database[achievementDatabaseScript.index].isUnlocked = true;
        achievementDatabaseScript.achievementPanel.UpdateList();
        achievementDatabaseScript.index++;

        // Change product of player
        productManager.ChangeProduct();
        productManager.index++;
    }

    private void SetInActive()
    {
        gameObject.SetActive(false);
    }
}
