using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI text; // drag your text object here
    public int ScoreTime = 0;

    void Start()
    {
        text.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
        ScoreTime++;
        text.text = ("Score: " + ScoreTime);
    }
}
