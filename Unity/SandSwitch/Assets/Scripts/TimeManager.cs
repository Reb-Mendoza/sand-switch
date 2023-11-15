using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public float timerText = 0;
    public float startTime = 0;
    public float endTime = 0;
    public TMP_Text textComponent;
    public Material textMaterial;
    public GameObject gameManager;
    public GameObject sandwichManager;
    //When this script is enabled, continuously update the UI to reflect the time.
    void OnEnable(){
        startTime = Time.time;
    }
    void Update(){
        //When this script is enabled, continuously update the UI to reflect the time.
        endTime = Time.time;
        timerText = 60 - (endTime - startTime);
        if (endTime - startTime > 60){
            textComponent.text = "STOP";
            gameManager.GetComponent<GameManager>().EndGame();
        } else {
            textComponent.text = timerText.ToString("00.000");
        }
    }

    void SandwichFinalScore(){
        gameObject.GetComponent<TimeManager>().enabled = false;
    }
}
