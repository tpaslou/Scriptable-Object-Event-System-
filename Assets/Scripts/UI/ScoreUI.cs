using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [Tooltip("Value to use as the current ")]
    public FloatReference Variable;
    
    [Tooltip("Score text to set the  amount on." )]
    public Text text;

    public void Update()
    {
        text.text = Variable.Value.ToString();
    }
}
