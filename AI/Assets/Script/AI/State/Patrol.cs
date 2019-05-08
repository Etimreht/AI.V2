using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Patrol : StateBase
{
    public Patrol(GuardMain guardMain) : base(guardMain.gameObject)
    {
        
    }

    public override Type Tick()
    {
        var TargetChase = CheckAggro();
        if (TargetChase != null)
        {

        }

        return null;
    }


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
