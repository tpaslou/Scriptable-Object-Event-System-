using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileHit : MonoBehaviour
{
    public FloatVariable Points;
    public UnityEvent PointAdd;
    private void OnTriggerEnter(Collider other)
    {
        PointIncrease point = other.gameObject.GetComponent<PointIncrease>();
        if (point != null)
        {
            Points.ApplyChange(+point.PointAmount);
            PointAdd.Invoke();
            Destroy(gameObject);
        }
    }
}
