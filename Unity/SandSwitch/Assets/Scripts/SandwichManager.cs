using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SandwichManager : MonoBehaviour
{
    public int connectionCount = 0;
    public SandwichAccuracy[] ingredients;
    public float sandwichScore = 0;
    public int sandwichStars = 0;
    public TMP_Text textComponent;
    public Material textMaterial;
    public void SandwichFinalScore(){
        connectionCount++;
        if (connectionCount == (gameObject.transform.childCount - 1)){
            ingredients = GetComponentsInChildren<SandwichAccuracy>();
            foreach (SandwichAccuracy i in ingredients){
                sandwichScore = sandwichScore + i.score;
            }
            sandwichScore = sandwichScore / (connectionCount);
            sandwichStars = Mathf.FloorToInt(sandwichScore);
            UnityEngine.Debug.Log("Pure Score: " + sandwichScore);
            UnityEngine.Debug.Log("Star Score: " + sandwichStars);
            textComponent.text = sandwichStars.ToString("0") + "-Star Sandwich!";
        }
    }
}
