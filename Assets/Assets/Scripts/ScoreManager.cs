﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    private UnityEngine.UI.Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<UnityEngine.UI.Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;
    }
}
