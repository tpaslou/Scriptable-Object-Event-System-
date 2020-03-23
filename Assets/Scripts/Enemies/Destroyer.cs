using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    
    [Tooltip("Time to destroy the object automatically.")]
    public float timeOut = 5.0f;
    public bool detachChildren = false;

    void Awake () {
        // invote the DestroyNow funtion to run after timeOut seconds
        Invoke ("DestroyNow", timeOut);
    }
	

    void DestroyNow ()
    {
        if (detachChildren) { // detach the children before destroying if specified
            transform.DetachChildren ();
        }

        // destory the game Object
        Destroy(gameObject);
    }
}
