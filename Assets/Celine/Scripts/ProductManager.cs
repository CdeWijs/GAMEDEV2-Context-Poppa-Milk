using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour {

    public int index = 0;
    public Animator head;         // declare in inspector

    public void ChangeProduct()
    {
        switch (index)
        {
            case 0:
                head.SetBool("isHaard", true);
                head.SetBool("isLamp", false);
                break;

            case 1:
                head.SetBool("isMirror", true);
                head.SetBool("isHaard", false);
                break;

            case 2:
                head.SetBool("isPerfume", true);
                head.SetBool("isMirror", false);
                break;

            case 3:
                head.SetBool("isWasher", true);
                head.SetBool("isPerfume", false);
                break;
        }
    }
}
