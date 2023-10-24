using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float hitpoints = 100f;

    public void adjustHitpoints(float amount){
        hitpoints = hitpoints + amount;
    }
}
