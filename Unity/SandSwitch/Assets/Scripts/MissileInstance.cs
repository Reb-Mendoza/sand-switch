using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileInstance : MonoBehaviour
{
    public float damageValue = 0;

    void FixedUpdate(){
        //Move the missile forward according to the direction it's facing.
        gameObject.transform.position += Vector3.forward * 0.1f;
    }

    void OnTriggerEnter(Collider other){
        //If the missile hits a player, disappear and deal damage.
        UnityEngine.Debug.Log("Collision!");
        if (other.tag == "Player"){
            other.gameObject.GetComponent<PlayerManager>().AdjustHitpoints(damageValue);
            UnityEngine.Debug.Log("You've been hit by a missile for " + damageValue + " damage!");
        }
    }
}
