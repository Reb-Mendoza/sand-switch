using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float hitpoints = 100f;
    public bool standingInLava = false;

    public void AdjustHitpoints(float amount){
        hitpoints = hitpoints + amount;
    }
}
