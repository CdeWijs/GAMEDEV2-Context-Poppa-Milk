using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Product {
    HAARD,
    LAMP,
    MIRROR,
    PERFUME,
    WASHER
}

public class ProductManager : MonoBehaviour
{
    public Animator head;         // declare in inspector
    
    public void ChangeProduct(Product product)
    {
        switch (product)
        {
            case Product.HAARD:
                head.SetBool("isHaard", true);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher", false);
                break;

            case Product.LAMP:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", true);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher", false);
                break;

            case Product.MIRROR:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", true);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher", false);
                break;

            case Product.PERFUME:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", true);
                head.SetBool("isWasher", false);
                break;

            case Product.WASHER:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher", true);
                break;

            default:
                break;
        }
    }
}
