using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject missile;
    public Vector3 targetPosition;
    public Vector2 randomRadius;
    public int shoot;
    public void SpawnAimedMissile(float damage){
        //Spawn a missile facing the player.
        targetPosition = GameObject.FindWithTag("Player").transform.position;
        randomRadius = UnityEngine.Random.insideUnitCircle.normalized * 20;
        Instantiate(missile, (new Vector3(randomRadius.x, 0, randomRadius.y) + targetPosition), (Quaternion.LookRotation(targetPosition - (new Vector3(randomRadius.x, 0, randomRadius.y) + targetPosition)) * Quaternion.Euler(0,RandomGaussian(-50,50),0))).GetComponent<MissileInstance>().damageValue = damage;
    }
    public void FixedUpdate(){
        if (shoot > 0){
            SpawnAimedMissile(20);
            shoot--;
        }
    }
    public static float RandomGaussian(float minValue = 0.0f, float maxValue = 1.0f)
    {
        float u, v, S;

        do
        {
            u = 2.0f * UnityEngine.Random.value - 1.0f;
            v = 2.0f * UnityEngine.Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);

        // Standard Normal Distribution
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);

        // Normal Distribution centered between the min and max value
        // and clamped following the "three-sigma rule"
        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
    }
}