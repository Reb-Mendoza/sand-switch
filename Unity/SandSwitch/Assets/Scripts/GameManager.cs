using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public void EndGame(){
        BroadcastMessage("SandwichFinalScore");
    }
}
