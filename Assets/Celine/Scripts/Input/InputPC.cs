using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPC : InputSystem {

	public override float GetAxis(GameAction action)
    {
        switch (action)
        {
            case GameAction.MOVE_HORIZONTAL:
                return Input.GetAxis("Horizontal");
            case GameAction.JUMP:
                return Input.GetAxis("Vertical");
            default:
                return 0;
        }
    }

    public override bool GetColliderInteraction(Collider2D collision, LayerMask layerMask, string name)
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, layerMask);
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
        return false;
    }
}
