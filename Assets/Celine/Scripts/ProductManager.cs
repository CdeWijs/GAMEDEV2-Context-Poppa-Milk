using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Product {
    FIRE_PLACE, LAMP, MIRROR, PERFUME, WASHER, BEER, BEER_BOTTLE,
    CANDLE, FISHBOWL, FRUITBASKET, GLASSES, GREEN_BOTTLE,
    JAR1, JAR2, MAGNIFYING_GLASS, MILK_BOTTLE, SNOW_GLOBE, TEA,
    VASE, WHINE_GLASS, ALARM_CLOCK, CLOCK, HAND_HELD_MIRROR,
    MAKEUP_MIRROR, STANDING_MIRROR, MICROWAVE, TV_NEW, TV_OLD, PC,
    MOBILE, PHOTO_FRAME, WASHER1, WASHER2,  WASHER3, WINDOW
}

public class ProductManager : MonoBehaviour
{
    public Animator head;         // declare in inspector
    
    public void ChangeProduct(Product product)
    {
        switch (product)
        {
            case Product.FIRE_PLACE:
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
