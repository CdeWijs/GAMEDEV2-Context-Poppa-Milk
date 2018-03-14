using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMobile : InputSystem {

    public static InputMobile instance;

    private float horizontalInput;
    private float verticalInput;

    private Vector2 touchOrigin = -Vector2.one;
    private Vector2 firstTouchPosition1;
    private Vector2 lastTouchPosition1;
    private Vector2 firstTouchPosition2;
    private Vector2 lastTouchPosition2;
    private float dragDistance;
    private float screenCenterX;
    private float screenTopY;

    public InputMobile() {
        instance = this;

        screenCenterX = Screen.width * 0.4f;
        dragDistance = Screen.height * 5 / 100; //dragDistance is 15% height of the screen
        }

    public override float GetAxis(GameAction action) {
        switch (action) {
            case GameAction.MOVE_HORIZONTAL:
                return horizontalInput;
            case GameAction.JUMP:
                return verticalInput;
            case GameAction.DUCK:
                return verticalInput;
            default:
                return 0;
            }
        }

    public override void CheckInput() {
        if (Input.touchCount > 0) {
            // get the first touch
            Touch firstTouch = Input.GetTouch(0);
            DetectTouch(firstTouch);

            // get the second touch
            Touch secondTouch = Input.GetTouch(1);
            DetectTouch(secondTouch);
            }
        }

    private void DetectTouch(Touch touch) {
        if (touch.phase == TouchPhase.Began) {
            firstTouchPosition2 = touch.position;
            lastTouchPosition2 = touch.position;
            }
        else if (touch.phase == TouchPhase.Moved) {
            lastTouchPosition2 = touch.position;

            if (touch.position.x > screenCenterX) {
                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lastTouchPosition2.x - firstTouchPosition2.x) > dragDistance || Mathf.Abs(lastTouchPosition2.y - firstTouchPosition2.y) > dragDistance) {
                    if (Mathf.Abs(lastTouchPosition2.x - firstTouchPosition2.x) > Mathf.Abs(lastTouchPosition2.y - firstTouchPosition2.y)) {   //the horizontal movement is greater than the vertical movement
                        if (lastTouchPosition2.x > firstTouchPosition2.x)  //If the movement was to the right
                        {
                            horizontalInput = 1;
                            }
                        if (lastTouchPosition2.x < firstTouchPosition2.x) // If the movement was to the left
                        {
                            horizontalInput = -1;
                            }
                        }
                    }
                }
            else if (touch.position.x < screenCenterX) {
                //Check if drag distance is greater than 15% of the screen height
                if (Mathf.Abs(lastTouchPosition2.x - firstTouchPosition2.x) > dragDistance || Mathf.Abs(lastTouchPosition2.y - firstTouchPosition2.y) > dragDistance) {
                    if (Mathf.Abs(lastTouchPosition2.x - firstTouchPosition2.x) > Mathf.Abs(lastTouchPosition2.y - firstTouchPosition2.y)) {   //the vertical movement is greater than the horizontal movement
                        if (lastTouchPosition2.y > firstTouchPosition2.y)  //If the movement was upwards
                        {
                            verticalInput = 1;
                            }
                        if (lastTouchPosition2.y < firstTouchPosition2.y) // If the movement was downwards
                        {
                            verticalInput = -1;
                            }
                        }
                    }
                }
            }
        else if (touch.phase == TouchPhase.Ended) {
            verticalInput = 0;
            horizontalInput = 0;
            }
        }

    public override bool GetColliderInteraction(Collider2D collision, LayerMask layerMask, string name) {
        for (var i = 0; i < Input.touchCount; ++i) {
            if (Input.GetTouch(i).phase == TouchPhase.Began) {
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero, layerMask);
                // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                if (hitInfo) {
                    Debug.Log(hitInfo.transform.gameObject.name);
                    if (hitInfo.transform.gameObject.GetComponent<Collider2D>() == collision || hitInfo.transform.gameObject.name == name) {
                        return true;
                        }
                    }
                }
            }
        return false;

        }
    }

