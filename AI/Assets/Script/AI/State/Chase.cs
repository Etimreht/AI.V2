using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Chase : StateBase
{
    private GuardMain guardMain;




    public Chase(GuardMain guardmain) : base(guardmain.gameObject)
    {
        guardMain = guardmain;
    }

    public override Type Tick()
    {
        if (guardMain.Target == null)
        {
            return typeof(Patrol);
        }

        transform.LookAt(guardMain.Target);
        transform.Translate(Vector3.forward * guardMain.speed * Time.deltaTime);
        
        return null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            ///reset game stuff
        }
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
