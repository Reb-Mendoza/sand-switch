using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichAccuracy : MonoBehaviour
{
    public float sqrLenCenters;
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
            //lenOffset uses the Pythagoren Theorm to find the relative horizontal offset of the ingredients given the distance between their centers as well as the thickness of each ingredient.
            sqrLenCenters = (gameObject.transform.position - collisionInfo.collider.gameObject.transform.position).sqrMagnitude;
            lenOffset = Mathf.Sqrt(sqrLenCenters - (((gameObject.transform.lossyScale.y / 2) + (collisionInfo.collider.gameObject.transform.lossyScale.y / 2)) * ((gameObject.transform.lossyScale.y / 2) + (collisionInfo.collider.gameObject.transform.lossyScale.y / 2))));
            lenTargetComponent = collisionInfo.collider.gameObject.transform.lossyScale.x;
            //lenOffset / lenTargetComponent has possible values of 0-2. Closer to 0 is better. 1 means the sandwich component is exactly halfway to the center.
            //Judge the accuracy of the ingredient on a scale of 1-3.
            UnityEngine.Debug.Log(Vector3.ProjectOnPlane(new Vector3(4f,3f,3f), new Vector3(0f,1f,0f)).magnitude);
            UnityEngine.Debug.DrawRay(Vector3.zero,(Vector3.ProjectOnPlane(new Vector3(4f,3f,3f), new Vector3(0f,1f,0f))),Color.black,100,false);
            if ((lenOffset / lenTargetComponent) < 1f){
                score++;
            }
            if ((lenOffset / lenTargetComponent) < 0.5f){
                score++;
            }
            if ((lenOffset / lenTargetComponent) < 0.1f){
                score++;
            }
        }
    }
}