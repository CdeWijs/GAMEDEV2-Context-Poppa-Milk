using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Product {
    FIRE_PLACE, LAMP, MIRROR, PERFUME, WASHER, BEER, BEER_BOTTLE,
    CANDLE, FISHBOWL, FRUITBASKET, GLASSES, GREEN_BOTTLE,
    JAR1, JAR2, MAGNIFYING_GLASS, MILK_BOTTLE, SNOW_GLOBE, TEA,
    VASE, WHINE_GLASS, ALARM_CLOCK, CLOCK, HAND_HELD_MIRROR,
    MAKEUP_MIRROR, STANDING_MIRROR, MICROWAVE, TV_NEW, TV_OLD, PC,
    MOBILE, PHOTO_FRAME, WASHER1, WASHER2,  WASHER3, WINDOW
}

public class ProductManager : MonoBehaviour, IObservable
{
    public Animator head;         // declare in inspector

    private int timesChanged = 0;
    private List<IObserver> observers = new List<IObserver>();
    private Scene currentScene;
    private AchievementDatabase achievementDatabase;

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += ChangeCurrentSceneIndex;
    }

    private void Start()
    {
        achievementDatabase = FindObjectOfType<AchievementDatabase>();
        AddObserver(achievementDatabase);
    }

    // Add observer
    public virtual void AddObserver(IObserver observer)
    {
        this.observers.Add(observer);
    }

    // Remove observer
    public virtual void RemoveObserver(IObserver observer)
    {
        this.observers.Remove(observer);
    }

    // Notify observers of event
    public virtual void NotifyObservers(GameEvent ev)
    {
        foreach (var observer in this.observers)
        {
            observer.OnNotify(ev);
        }
    }

    private void ChangeCurrentSceneIndex(Scene prevScene, Scene newScene)
    {
        currentScene = newScene;

        if (currentScene.buildIndex == 2) { NotifyObservers(GameEvent.Complete_First_Level); }
        if (currentScene.buildIndex == 3) { NotifyObservers(GameEvent.Complete_Second_Level); }
        if (currentScene.buildIndex == 4) { NotifyObservers(GameEvent.Completed_Third_Level); }
    }

    public void ChangeProduct(Product product)
    {
        // Get number of times player has changed into a new product per episode
        timesChanged++;

        // Check when player changes into first product
        bool firstProductChange = false;
        if (currentScene.buildIndex == 1 && timesChanged > 0 && firstProductChange == false)
        {
            firstProductChange = true;
            this.NotifyObservers(GameEvent.Change_Into_First_Product);
        }

        // Check when player changes into first remanufactured product
        bool firstRemanufactureChange = false;
        if (currentScene.buildIndex == 2 && timesChanged > 0 && firstRemanufactureChange == false)
        {
            firstRemanufactureChange = true;
            this.NotifyObservers(GameEvent.Change_Into_First_Remanufactured_Product);
        }

        switch (product)
        {
            case Product.FIRE_PLACE:
                head.SetBool("isHaard", true);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.LAMP:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", true);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.MIRROR:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", true);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", true);
                head.SetBool("isCandle", true);
                head.SetBool("isFishBowl", true);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.PERFUME:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", true);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.WASHER1:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", true);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.BEER:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", true);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.BEER_BOTTLE:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", true);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.CANDLE:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", true);
                head.SetBool("isFishBowl", true);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.FISHBOWL:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", true);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.FRUITBASKET:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", true);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.GLASSES:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", true);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.GREEN_BOTTLE:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", true);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.JAR1:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", true);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.JAR2:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", true);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.MAGNIFYING_GLASS:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", true);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.MILK_BOTTLE:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", true);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.SNOW_GLOBE:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", true);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.TEA:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", true);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.VASE:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", true);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.WHINE_GLASS:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", true);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.ALARM_CLOCK:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", true);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.CLOCK:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", true);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.HAND_HELD_MIRROR:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", true);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.MAKEUP_MIRROR:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", true);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.MICROWAVE:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", true);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.TV_NEW:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", true);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.TV_OLD:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", true);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.PC:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", true);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.MOBILE:
                NotifyObservers(GameEvent.Change_Into_Phone);
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", true);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.PHOTO_FRAME:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", true);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.WASHER2:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", true);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.WASHER3:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", true);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.WINDOW:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", true);
                head.SetBool("isStandingMirror", false);
                break;

            case Product.STANDING_MIRROR:
                head.SetBool("isHaard", false);
                head.SetBool("isLamp", false);
                head.SetBool("isMirror", false);
                head.SetBool("isPerfume", false);
                head.SetBool("isWasher1", false);
                head.SetBool("isBeer", false);
                head.SetBool("isBeerBottle", false);
                head.SetBool("isCandle", false);
                head.SetBool("isFishBowl", false);
                head.SetBool("isFruitBasket", false);
                head.SetBool("isGlasses", false);
                head.SetBool("isGreenBottle", false);
                head.SetBool("isJar1", false);
                head.SetBool("isJar2", false);
                head.SetBool("isMagnifyingGlass", false);
                head.SetBool("isMilkBottle", false);
                head.SetBool("isSnowGlobe", false);
                head.SetBool("isTea", false);
                head.SetBool("isVase", false);
                head.SetBool("isWhineGlass", false);
                head.SetBool("isAlarm", false);
                head.SetBool("isClock", false);
                head.SetBool("isHandHeldMirror", false);
                head.SetBool("isMakeupMirror", false);
                head.SetBool("isMicroWave", false);
                head.SetBool("isNewTV", false);
                head.SetBool("isOldTV", false);
                head.SetBool("isPC", false);
                head.SetBool("isPhone", false);
                head.SetBool("isPhotoFrame", false);
                head.SetBool("isWasher2", false);
                head.SetBool("isWasher3", false);
                head.SetBool("isWindow", false);
                head.SetBool("isStandingMirror", true);
                break;

            default:
                break;
        }
    }
}
