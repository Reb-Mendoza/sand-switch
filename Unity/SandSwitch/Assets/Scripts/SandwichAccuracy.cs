using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichAccuracy : MonoBehaviour
{
    public Vector3 normal;
    public Vector3 myCenter;
    public Vector3 otherCenter;
    public float offsetMagnitude;
    public float offsetPercent;
    public int score = 0;
    void OnCollisionEnter(Collision collisionInfo){
        //If there is a sufficient collision between two sandwich components,
        if (collisionInfo.contactCount > 2 && collisionInfo.collider.gameObject.CompareTag("SandwichComponent") && !(TryGetComponent<FixedJoint>(out FixedJoint joint))){
            //Have them stick together.
            gameObject.AddComponent<FixedJoint>().connectedBody = collisionInfo.collider.gameObject.GetComponent<Rigidbody>();
            //Measure how accurately placed they are by measuring the distance between the component's centers by projecting the vector from center to center of each touching component onto the plane perpendicular to the normal of the collision.
            normal = collisionInfo.GetContact(0).normal;
            myCenter = gameObject.transform.position;
            otherCenter = collisionInfo.collider.gameObject.transform.position;
            offsetMagnitude = (Vector3.ProjectOnPlane((myCenter - otherCenter), normal)).magnitude;
            //offsetPercent represents a percentage of how off the sandwich component is.
            offsetPercent = (offsetMagnitude / collisionInfo.collider.gameObject.GetComponent<BoxCollider>().size.x);
            if (offsetPercent < 60.0f){
                score++;
            }
            if (offsetPercent < 40.0f){
                score++;
            }
            if (offsetPercent < 20.0f){
                score++;
            }
            GameObject.FindWithTag("SandwichManager").GetComponent<SandwichManager>().SandwichFinalScore();
        }
    }
}