using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Threadmill : MonoBehaviour
{
    public float speed = 3;

    private List<GameObject> objectsInTrigger = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ThreadmillMovable>())
        {
            objectsInTrigger.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ThreadmillMovable>())
        {
            objectsInTrigger.Remove(collision.gameObject);
        }
    }

    private void Update()
    {
        if (objectsInTrigger.Count > 0)
        {
            for (int i = 0; i < objectsInTrigger.Count; i++)
            {
                objectsInTrigger[i].transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
    }
}
