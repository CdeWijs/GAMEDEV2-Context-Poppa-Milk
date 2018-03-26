using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupParticleEffect : MonoBehaviour
{
    public void SetParticlesActive(bool isActive)
    {
        transform.GetChild(0).gameObject.SetActive(isActive);
    }

    public void ChangeLocation(Vector3 targetLocation)
    {
        transform.position = targetLocation;
    }
}
