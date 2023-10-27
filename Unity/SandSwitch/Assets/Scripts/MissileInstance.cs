using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileInstance : MonoBehaviour
{
    public float damageValue = 0;
    public Vector3 targetPosition;
    public Vector3 myPosition;
    void Start(){
        //Rotate the missile to face towards the player.
        gameObject.transform.rotation = Quaternion.LookRotation(targetPosition - myPosition);
    }

    void FixedUpdate(){

    }

    void OnCollisionEnter(Collision collisionInfo){

    }
}
