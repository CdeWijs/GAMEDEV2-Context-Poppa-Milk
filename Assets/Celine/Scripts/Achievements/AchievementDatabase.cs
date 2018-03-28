using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AchievementDatabase : MonoBehaviour, IObserver
{
    public Sprite[] achievementSprites;
    public List<Achievement> achievementDatabase = new List<Achievement>();
    public AchievementPanel achievementPanel;
    
    private void Awake()
    {        
        // CREATE YOUR ACHIEVEMENTS HERE:

        // Achievement 1
        Achievement achievement1 = new Achievement();
        achievement1.Name = "See What Happens";
        achievement1.isUnlocked = false;
        achievement1.Sprite = achievementSprites[0];
        achievementDatabase.Add(achievement1);

        // Achievement 2
        Achievement achievement2 = new Achievement();
        achievement2.Name = "Recycling Is Not The Only Way";
        achievement2.isUnlocked = false;
        achievement2.Sprite = achievementSprites[1];
        achievementDatabase.Add(achievement2);

        // Achievement 3
        Achievement achievement3 = new Achievement();
        achievement3.Name = "Less Producing, More Reusing";
        achievement3.isUnlocked = false;
        achievement3.Sprite = achievementSprites[2];
        achievementDatabase.Add(achievement3);

        // Achievement 4
        Achievement achievement4 = new Achievement();
        achievement4.Name = "Picked Up in Africa";
        achievement4.isUnlocked = false;
        achievement4.Sprite = achievementSprites[0];
        achievementDatabase.Add(achievement4);

        // Achievement 5
        Achievement achievement5 = new Achievement();
        achievement5.Name = "Better Than REcycling";
        achievement5.isUnlocked = false;
        achievement5.Sprite = achievementSprites[1];
        achievementDatabase.Add(achievement5);

        // Achievement 6
        Achievement achievement6 = new Achievement();
        achievement6.Name = "Endure The Jokes";
        achievement6.isUnlocked = false;
        achievement6.Sprite = achievementSprites[2];
        achievementDatabase.Add(achievement6);

        // Achievement 7
        Achievement achievement7 = new Achievement();
        achievement7.Name = "Always Listen To Poppa";
        achievement7.isUnlocked = false;
        achievement7.Sprite = achievementSprites[3];
        achievementDatabase.Add(achievement7);
    }

    public void OnNotify(GameEvent ev)
    {
        switch (ev)
        {
            case GameEvent.Change_Into_First_Product:
                UnlockAchievement(achievementDatabase[0]);
                Debug.Log("Unlocked 'Change Into First Product'");
                break;
            case GameEvent.Change_Into_First_Remanufactured_Product:
                UnlockAchievement(achievementDatabase[2]);
                Debug.Log("Change INto First Remanufactured Product'");
                break;
            case GameEvent.Change_Into_Phone: // TODO NOTIFY
                UnlockAchievement(achievementDatabase[3]);
                Debug.Log("Unlocked 'Change Into Phone'");
                break;
            case GameEvent.Complete_First_Level: // TODO NOTIFY
                UnlockAchievement(achievementDatabase[1]);
                Debug.Log("Unlocked 'Complete First Level'");
                break;
            case GameEvent.Complete_Second_Level: // TODO NOTIFY
                UnlockAchievement(achievementDatabase[4]);
                Debug.Log("Unlocked 'Complete Second Level'");
                break;
            case GameEvent.Completed_Third_Level: // TODO NOTIFY
                UnlockAchievement(achievementDatabase[6]);
                Debug.Log("Unlocked 'Complete Third Level'");
                break;
            case GameEvent.Poppa_Made_Second_Joke: // TODO NOTIFY
                UnlockAchievement(achievementDatabase[5]);
                Debug.Log("Unlocked 'Poppa Made Second Joke'");
                break;
            default:
                break;
        }
        achievementPanel.UpdateList();
    }

    private void UnlockAchievement(Achievement achievement)
    {
        achievement.isUnlocked = true;
    }
}
