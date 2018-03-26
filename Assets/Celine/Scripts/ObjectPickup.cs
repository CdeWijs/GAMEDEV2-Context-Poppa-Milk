using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour, IInteractable
{
    public LayerMask layerMask;     // declare in inspector to "Object"

    [SerializeField]
    private bool clickable;
    [SerializeField]
    private int scoreAmount = 10;
    [SerializeField]
    private Transform targetPos;

    private PlayerController playerController;
    private InputSystem inputSystem;
    private Collider2D collision2D = null;
    private Animator animator;

    private void Start() {
        // Get player controller for player check, and input system for multiplatform use
        playerController = FindObjectOfType<PlayerController>();
        inputSystem = playerController.inputSystem;

        // Get target position where the object transports to when clicked on
        targetPos = GameObject.FindGameObjectWithTag("target").transform;
        collision2D = GetComponent<Collider2D>();
    }

    private void Update() {
        transform.parent.transform.position = transform.position;
    }

    // Called from Input System
    public void OnClick() {
        if (clickable) {
            HandleClickedObject();
        }
    }

    // Called from ObjectKillzone and OnClick
    private void HandleClickedObject() {
        GameManager.instance.scoreTracker.UpdateScore(scoreAmount);
        transform.parent.transform.position = targetPos.position;
        GameManager.instance.scoreTracker.UpdateScore(scoreAmount);
    }

    // Called from ObjectSpawner
    public void SetRandom() {
        int random = Random.Range(0, 100);

        // The object has 40% chance of being clickable and thus recyclable.
        if (random < 40) {
            clickable = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red; // TEMP HACK
        }
        else {
            clickable = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white; // TEMP HACK
        }

        // Give the object a random scale
        transform.parent.transform.localScale = new Vector3(Random.Range(1, 4), Random.Range(1, 4), transform.localScale.z);
    }
}
