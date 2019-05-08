using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public Transform Target;

    private Vector3 TargetDirection;
    float angle;

    private void Update()
    {
        TargetDirection = Target.position - transform.position;
        angle = Vector3.Angle(TargetDirection, transform.forward);

        if (angle < 5.0f)
        {
            //Initiate State Switch
        }
    }
}
