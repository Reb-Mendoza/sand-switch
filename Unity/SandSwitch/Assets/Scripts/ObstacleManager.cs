using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject missile;
    public Vector3 targetPosition;
    public Vector2 randomRadius;
    public int shoot;
    public void Start(){
        missile = GameObject.FindWithTag("Missile");
    }
    public void SpawnAimedMissile(float damage){
        //Spawn a missile facing the player.
        targetPosition = GameObject.FindWithTag("Player").transform.position;
        randomRadius = UnityEngine.Random.insideUnitCircle * 20;
        Instantiate(missile, (new Vector3(randomRadius.x, 0, randomRadius.y) + targetPosition), Quaternion.LookRotation(targetPosition - (new Vector3(randomRadius.x, 0, randomRadius.y) + targetPosition))).GetComponent<MissileInstance>().damageValue = damage;
    }
    public void FixedUpdate(){
        if (shoot > 1){
            SpawnAimedMissile(20);
            shoot--;
        }
    }
}