using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclePickup : MonoBehaviour
{
    public bool clickable;

    private GameObject player;
    private PlayerController playerController;
    private InputSystem inputSystem;
    private List<Achievement> database;
    public LayerMask layerMask; // player
    
    public Collider2D collision2D = null;
    private Animator animator;

    private void Start()
    {
        // Get player controller for player check, and input system for multiplatform use
        playerController = FindObjectOfType<PlayerController>();
        player = playerController.gameObject;
        inputSystem = playerController.inputSystem;
        
        collision2D = GetComponent<Collider2D>();
        animator = GetComponentInChildren<Animator>();
        animator.enabled = false;
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

    public void OnClick()
    {
        Debug.Log("Clicked!");
        animator.SetTrigger("onClick");
    }

    private void SetInActive()
    {
        gameObject.SetActive(false);
    }

    public void SetClickable()
    {
        int random = Random.Range(0, 100);
        if (random < 40)
        {
            clickable = true;
        }
        else
        {
            clickable = false;
        }
    }
}
