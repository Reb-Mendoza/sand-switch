using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SandwichCheck : MonoBehaviour
{
    public string bruh;
    public GameObject seed;
    public GameObject seedCount;
    // Start is called before the first frame update
    void Start()
    {
        bruh = "heyo";
        UnityEngine.Debug.Log(bruh);
        seed = GameObject.Find("BottomBun");
        UnityEngine.Debug.Log(seed);
        seedCount = seed.GetComponent<Sesame>().gameObject;
        UnityEngine.Debug.Log(seedCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}