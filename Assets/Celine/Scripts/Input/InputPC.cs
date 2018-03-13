using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPC : InputSystem {

    public override float GetAxis(GameAction action) {
        switch (action) {
            case GameAction.MOVE_HORIZONTAL:
                return Input.GetAxis("Horizontal");
            case GameAction.JUMP:
                return Input.GetAxis("Vertical");
            case GameAction.DUCK:
                return Input.GetAxis("Vertical");
            default:
                return 0;
        }
    }

    public override bool GetColliderInteraction(Collider2D collision, LayerMask layerMask, string name) {
        if (Input.GetMouseButtonDown(0)) {
            //determine location of camera and clicked position (assumes the blocks are at z = 0)
            Vector3 MouseLocation = Input.mousePosition;
            Vector3 sourcePos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
            MouseLocation.z = -sourcePos.z;
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(MouseLocation);

            //determine direction of raycast
            Vector3 direction = targetPos - sourcePos;

            //make the actual raycast
            Debug.DrawRay(sourcePos, direction, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(sourcePos, direction, out hit, 250f)) {//{, layerMask)) {
                Debug.Log("Hit");
                if (hit.transform.gameObject.GetComponent<Collider2D>() == collision || hit.transform.gameObject.name == name) {
                    return true;
                }
                Debug.Break();
            }
            /*
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, layerMask);
            // RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
            if (hitInfo)
            {
                Debug.Log(hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.GetComponent<Collider2D>() == collision || hitInfo.transform.gameObject.name == name)
                {
                    return true;
                }
            }*/


        }
        return false;
    }
}
/*
    public void MouseHit(Vector3 pos) {

		//determine location of camera and clicked position (assumes the blocks are at z = 0)
		Vector3 MouseLocation = Input.mousePosition;
		Vector3 sourcePos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
		MouseLocation.z = -sourcePos.z;
		Vector3 targetPos = Camera.main.ScreenToWorldPoint(MouseLocation);

		//determine direction of raycast
		Vector3 direction = targetPos - sourcePos;

		//make the actual raycast
		Debug.DrawRay(sourcePos, direction, Color.red);
		RaycastHit hit;
		if (Physics.Raycast(sourcePos, direction, out hit, 200f)) {
		}	
	} 
 */
