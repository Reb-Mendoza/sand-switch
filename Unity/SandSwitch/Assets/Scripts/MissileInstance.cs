using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileInstance : MonoBehaviour
{
    public float damageValue = 0f;

    void FixedUpdate(){
        //Move the missile forward according to the direction it's facing.
        transform.Translate(Vector3.forward * 0.1f);
    }

    void OnTriggerEnter(Collider other){
        //If the missile hits a player, disappear and deal damage.
        UnityEngine.Debug.Log("Collision!");
        if (other.tag == "Player"){
            other.gameObject.GetComponentInParent<PlayerManager>().AdjustHitpoints(-1 * damageValue);
            UnityEngine.Debug.Log("You've been hit by a missile for " + damageValue + " damage!");
        }
    }
}