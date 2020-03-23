using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPoints : MonoBehaviour
{
    // Start is called before the first frame update
    public FloatVariable Points;
    public bool ResetPoints;
    
    private void Start()
    {
        if (ResetPoints)
            Points.SetValue(0);
    }


}