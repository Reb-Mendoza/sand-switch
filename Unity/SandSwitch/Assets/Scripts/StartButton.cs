using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject timeManager;
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
            timeManager.GetComponent<TimeManager>().enabled = true;
        }
    }
}
