using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public LayerMask layerMask;     // declare in inspector to "Object"

    [SerializeField]
    private bool clickable;
    
    private PlayerController playerController;
    private InputSystem inputSystem;
    
    private Collider2D collision2D = null;
    private Animator animator;

    private void Start()
    {
        // Get player controller for player check, and input system for multiplatform use
        playerController = FindObjectOfType<PlayerController>();
        inputSystem = playerController.inputSystem;
        
        collision2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        transform.parent.transform.position = transform.position;

        if (clickable && inputSystem.GetColliderInteraction(collision2D, layerMask, transform.parent.name))
        {
            Debug.Log("Clicked");
            OnClick();
        }
    }

    public void OnClick()
    {
        SetInActive();
    }
    
    // Called from ObjectKillzone
    private void SetInActive()
    {
        transform.parent.gameObject.SetActive(false);
    }
    
    public void SetRandom()
    {
        int random = Random.Range(0, 100);
        if (random < 40)
        {
            clickable = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red; // TEMP HACK
        }
        else
        {
            clickable = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white; // TEMP HACK
        }
        transform.parent.transform.localScale = new Vector3(Random.Range(1, 4), Random.Range(1, 4), transform.localScale.z);
    }
}
