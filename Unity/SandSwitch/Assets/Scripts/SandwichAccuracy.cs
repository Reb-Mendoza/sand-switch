using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichAccuracy : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.contactCount > 2 && collisionInfo.collider.gameObject.CompareTag("SandwichComponent") && !(TryGetComponent<FixedJoint>(out FixedJoint joint))){
            gameObject.AddComponent<FixedJoint>().connectedBody = collisionInfo.collider.gameObject.GetComponent<Rigidbody>();
        }
    }
}