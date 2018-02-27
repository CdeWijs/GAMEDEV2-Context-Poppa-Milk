using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPanel : MonoBehaviour
{
    public GameObject openButton;
    public GameObject closeButton;

    public GameObject achievementPrefab;
    public Transform achievementContainer;

    private AchievementDatabase databaseScript;
    private List<Achievement> database;
    private List<GameObject> achievementUI = new List<GameObject>();

    private PlayerController playerController;

    private void Start()
    {
        databaseScript = GetComponent<AchievementDatabase>();
        database = databaseScript.achievementDatabase;

        playerController = FindObjectOfType<PlayerController>();

        gameObject.SetActive(false);
        closeButton.SetActive(false);
        openButton.SetActive(true);

        CreateList();
        UpdateList();
    }

    public void OpenPanel()
    {
        gameObject.SetActive(true);
        openButton.SetActive(false);
        closeButton.SetActive(true);
        //playerController.ControlSwitch(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        closeButton.SetActive(false);
        openButton.SetActive(true);
        //playerController.ControlSwitch(false);
    }

    private void CreateList()
    {
        Vector2 containerSize = achievementContainer.GetComponent<RectTransform>().sizeDelta;
        //containerSize = new Vector2(0, 0);

        float padding = -Screen.height * 0.05f;
        for (int i = 0; i < database.Count; i++)
        {
            GameObject go = Instantiate(achievementPrefab);
            go.transform.SetParent(achievementContainer, false);
            go.GetComponent<RectTransform>().position = new Vector3(achievementContainer.position.x, achievementContainer.position.y + padding, 0);

            go.transform.GetChild(0).GetComponent<Image>().sprite = database[i].Sprite;
            go.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
            go.transform.GetChild(1).GetComponent<Text>().text = database[i].Name;
            go.transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0.3f);
            go.transform.GetChild(2).GetComponent<Text>().text = database[i].Description;
            go.transform.GetChild(2).GetComponent<Text>().color = new Color(1, 1, 1, 0.3f);

            achievementUI.Add(go);

            padding -= Screen.height * 0.2f;
        }
    }

    public void UpdateList()
    {
        for (int i = 0; i < achievementUI.Count; i++)
        {
            if(database[i].isUnlocked == true)
            {
                achievementUI[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                achievementUI[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                achievementUI[i].transform.GetChild(2).GetComponent<Text>().color = new Color(1, 1, 1, 1);
            }
            else if (database[i].isUnlocked == false)
            {
                achievementUI[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
                achievementUI[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0.3f);
                achievementUI[i].transform.GetChild(2).GetComponent<Text>().color = new Color(1, 1, 1, 0.3f);
            }
        }
    }
}
