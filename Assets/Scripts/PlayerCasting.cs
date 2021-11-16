using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float distanceFromTarget;
    public static GameObject hitTarget;
    public static bool hasTarget = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,
           transform.TransformDirection(Vector3.forward), out hit))
        {
            hasTarget = true;
            distanceFromTarget = hit.distance;
            hitTarget = hit.collider.gameObject;
        } else
        {
            hasTarget = false;
        }
    }
}
