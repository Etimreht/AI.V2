using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Investigate : StateBase
{
  
    private GuardMain guardMain;

    public Investigate(GuardMain guardmain) : base(guardmain.gameObject)
    {
        guardMain = guardmain;
    }

    public override Type Tick()
    {
        
        return null;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
