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
        achievementPanel = gameObject.GetComponent<AchievementPanel>();
        
        // CREATE YOUR ACHIEVEMENTS HERE:

        // Achievement 1
        Achievement achievement1 = new Achievement();
        achievement1.Name = "Pickup1";
        achievement1.isUnlocked = false;
        achievement1.Type = AchievementType.Pickup;
        achievement1.Sprite = achievementSprites[0];
        achievementDatabase.Add(achievement1);

        // Achievement 2
        Achievement achievement2 = new Achievement();
        achievement2.Name = "Pickup2";
        achievement2.isUnlocked = false;
        achievement2.Type = AchievementType.Pickup;
        achievement2.Sprite = achievementSprites[1];
        achievementDatabase.Add(achievement2);

        // Achievement 3
        Achievement achievement3 = new Achievement();
        achievement3.Name = "Pickup3";
        achievement3.isUnlocked = false;
        achievement3.Type = AchievementType.Pickup;
        achievement3.Sprite = achievementSprites[2];
        achievementDatabase.Add(achievement3);
    }
}
