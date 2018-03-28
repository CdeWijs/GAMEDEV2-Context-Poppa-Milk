using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public GameObject objectPrefab;
    public float timeBetweenObjects = 4.0f;

    private List<GameObject> objectPool = new List<GameObject>();
    private float time;

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject go = Instantiate(objectPrefab, transform.position, Quaternion.identity) as GameObject;
            objectPool.Add(go);
            go.SetActive(false);
        }

        // Set time immediately to timeBetweenObjects, so an object spawns at the start of the level
        time = timeBetweenObjects;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= timeBetweenObjects)
        {
            time = 0;

            for (int i = 0; i < objectPool.Count; i++)
            {
                if (!objectPool[i].activeInHierarchy)
                {
                    objectPool[i].SetActive(true);
                    objectPool[i].transform.rotation = new Quaternion(0, 0, 0,0);
                    objectPool[i].transform.position = transform.position;
                    objectPool[i].transform.GetChild(0).GetComponent<ObjectPickup>().SetRandom();

                    // If one object has been set active, stop looping
                    return;
                }
            }
        }
    }
}
