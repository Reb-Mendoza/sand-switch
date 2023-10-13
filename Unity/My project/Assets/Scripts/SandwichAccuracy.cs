using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichAccuracy : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        UnityEngine.Debug.Log(collisionInfo.contactCount);
        UnityEngine.Debug.Log(collisionInfo.collider);
        UnityEngine.Debug.Log(collisionInfo.collider.gameObject);
        UnityEngine.Debug.Log(collisionInfo.collider.gameObject.tag);
        if (collisionInfo.contactCount > 1 && collisionInfo.collider.gameObject.CompareTag("SandwichComponent")){
            UnityEngine.Debug.Log("I have more than one contact point on a sandwich component!");
        }
    }
}