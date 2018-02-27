using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementDatabase : MonoBehaviour
{
    public Sprite[] achievementSprites;
    public List<Achievement> achievementDatabase = new List<Achievement>();
    public AchievementPanel achievementPanel;

    public int index = 0;

    private void Awake()
    {
        achievementPanel = FindObjectOfType<AchievementPanel>();
        
        // CREATE YOUR ACHIEVEMENTS HERE:

        // Achievement 1
        Achievement achievement1 = new Achievement();
        achievement1.Name = "Pickup1";
        achievement1.Description = "Pick up one item.";
        achievement1.isUnlocked = false;
        achievement1.Type = AchievementType.Pickup;
        achievement1.Sprite = achievementSprites[0];
        achievementDatabase.Add(achievement1);

        // Achievement 2
        Achievement achievement2 = new Achievement();
        achievement2.Name = "Pickup2";
        achievement2.Description = "Pick up two items.";
        achievement2.isUnlocked = false;
        achievement2.Type = AchievementType.Pickup;
        achievement2.Sprite = achievementSprites[1];
        achievementDatabase.Add(achievement2);

        // Achievement 3
        Achievement achievement3 = new Achievement();
        achievement3.Name = "Pickup3";
        achievement3.Description = "Pick up three items.";
        achievement3.isUnlocked = false;
        achievement3.Type = AchievementType.Pickup;
        achievement3.Sprite = achievementSprites[2];
        achievementDatabase.Add(achievement3);

        // Achievement 4
        Achievement achievement4 = new Achievement();
        achievement4.Name = "Pickup4";
        achievement4.Description = "Pick up three items.";
        achievement4.isUnlocked = false;
        achievement4.Type = AchievementType.Pickup;
        achievement4.Sprite = achievementSprites[3];
        achievementDatabase.Add(achievement4);

        // Achievement 5
        Achievement achievement5 = new Achievement();
        achievement5.Name = "Pickup5";
        achievement5.Description = "Pick up three items.";
        achievement5.isUnlocked = false;
        achievement5.Type = AchievementType.Pickup;
        achievement5.Sprite = achievementSprites[4];
        achievementDatabase.Add(achievement5);

    }
}
