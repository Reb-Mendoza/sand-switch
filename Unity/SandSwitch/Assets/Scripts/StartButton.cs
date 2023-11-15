using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject timeManager;
    void OnTriggerEnter(){
        timeManager.GetComponent<TimeManager>().enabled = true;
    }
}
