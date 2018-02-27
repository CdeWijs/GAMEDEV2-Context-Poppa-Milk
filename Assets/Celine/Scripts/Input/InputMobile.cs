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

    public InputMobile()
    {
        instance = this;

        screenCenterX = Screen.width * 0.4f;
        dragDistance = Screen.height * 5 / 100; //dragDistance is 15% height of the screen
    }

    public override float GetAxis(GameAction action)
    {
        switch (action)
        {
            case GameAction.MOVE_HORIZONTAL:
                return horizontalInput;
            case GameAction.JUMP:
                return verticalInput;
            default:
                return 0;
        }
    }

    public void CheckInput()
    {
        if (Input.touchCount > 0)
        {
            // get the first touch
            Touch firstTouch = Input.GetTouch(0);
            
            // FIRST TOUCH
            if (firstTouch.phase == TouchPhase.Began)
            {
                // JUMP
                if (firstTouch.position.x < screenCenterX)
                {
                    verticalInput = 1;
                }

                firstTouchPosition1 = firstTouch.position;
                lastTouchPosition1 = firstTouch.position;
            }
            else if (firstTouch.phase == TouchPhase.Moved)
            {
                lastTouchPosition1 = firstTouch.position;

                if (firstTouch.position.x > screenCenterX)
                {
                    //Check if drag distance is greater than 20% of the screen height
                    if (Mathf.Abs(lastTouchPosition1.x - firstTouchPosition1.x) > dragDistance || Mathf.Abs(lastTouchPosition1.y - firstTouchPosition1.y) > dragDistance)
                    {
                        if (Mathf.Abs(lastTouchPosition1.x - firstTouchPosition1.x) > Mathf.Abs(lastTouchPosition1.y - firstTouchPosition1.y))
                        {   //the horizontal movement is greater than the vertical movement
                            if (lastTouchPosition1.x > firstTouchPosition1.x)  //If the movement was to the right
                            {
                                horizontalInput = 1;
                            }
                            if (lastTouchPosition1.x < firstTouchPosition1.x) // If the movement was to the left
                            {
                                horizontalInput = -1;
                            }
                        }
                    }
                }
            }
            else if (firstTouch.phase == TouchPhase.Ended)
            {
                verticalInput = 0;
                horizontalInput = 0;
            }


            // get the second touch
            Touch secondTouch = Input.GetTouch(1);

            // SECOND TOUCH
            if (secondTouch.phase == TouchPhase.Began)
            {
                // JUMP
                if (secondTouch.position.x < screenCenterX)
                {
                    verticalInput = 1;
                }

                firstTouchPosition2 = secondTouch.position;
                lastTouchPosition2 = secondTouch.position;
            }
            else if (secondTouch.phase == TouchPhase.Moved)
            {
                lastTouchPosition2 = secondTouch.position;

                if (secondTouch.position.x > screenCenterX)
                {
                    //Check if drag distance is greater than 20% of the screen height
                    if (Mathf.Abs(lastTouchPosition2.x - firstTouchPosition2.x) > dragDistance || Mathf.Abs(lastTouchPosition2.y - firstTouchPosition2.y) > dragDistance)
                    {
                        if (Mathf.Abs(lastTouchPosition2.x - firstTouchPosition2.x) > Mathf.Abs(lastTouchPosition2.y - firstTouchPosition2.y))
                        {   //the horizontal movement is greater than the vertical movement
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
            }
            else if (secondTouch.phase == TouchPhase.Ended)
            {
                verticalInput = 0;
                horizontalInput = 0;
            }
        }
    }

    public override bool GetColliderInteraction(Collider2D collision, LayerMask layerMask, string name)
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero, layerMask);
                // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
                if (hitInfo)
                {
                    Debug.Log(hitInfo.transform.gameObject.name);
                    if (hitInfo.transform.gameObject.GetComponent<Collider2D>() == collision || hitInfo.transform.gameObject.name == name)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

}

