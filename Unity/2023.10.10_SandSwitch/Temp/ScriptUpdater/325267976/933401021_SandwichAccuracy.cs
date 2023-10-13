using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichAccuracy : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        UnityEngine.Debug.Log(GetComponent<Collider>());
        UnityEngine.Debug.Log(contactCount);
    }
}