using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichAccuracy : MonoBehaviour
{
    public float lenOffset;
    public float lenTargetComponent;
    public int score = 0;
    void OnCollisionEnter(Collision collisionInfo)
    {
        //If there is a sufficient collision between two sandwich components,
        if (collisionInfo.contactCount > 2 && collisionInfo.collider.gameObject.CompareTag("SandwichComponent") && !(TryGetComponent<FixedJoint>(out FixedJoint joint))){
            //Have them stick together.
            gameObject.AddComponent<FixedJoint>().connectedBody = collisionInfo.collider.gameObject.GetComponent<Rigidbody>();
            //Measure how accurately placed they are by measuring the distance between the component's centers.
            lenOffset = (gameObject.transform.position - collisionInfo.collider.gameObject.transform.position).magnitude;
            lenTargetComponent = collisionInfo.collider.gameObject.transform.lossyScale.x;
            //lenOffset / lenTargetComponent has possible values of 0-2. Closer to 0 is better. 1 means the sandwich component is exactly halfway to the center.
            //Judge the accuracy of the ingredient on a scale of 1-3.
            if ((lenOffset / lenTargetComponent) < 1f){
                score++;
                UnityEngine.Debug.Log("One Star");
            }
            if ((lenOffset / lenTargetComponent) < 0.5f){
                score++;
                UnityEngine.Debug.Log("Two Star");
            }
            if ((lenOffset / lenTargetComponent) < 0.1f){
                score++;
                UnityEngine.Debug.Log("Three Star");
            }
            //IMPORTANT - Need to make the thickness of the component not matter in the calculation!!!
        }
    }
}