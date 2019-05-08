using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMain : MonoBehaviour
{
    public Transform Target { get; private set; }
    public StateMachine StateMachine;




	// Use this for initialization
	private void Awake ()
    {
        IntializeStateMachine();
	}
	
    private void IntializeStateMachine()
    {
        var StateList = new Dictionary<Type, StateBase>()
        {
            { typeof(Patrol), new Patrol(guardMain: this) },
           // { typeof(###), new ###(guardMain: this) },
           // { typeof(###), new ###(guardMain: this) }
            
        };

        GetComponent<StateMachine>().SetStates(states);
    }


    public void Targeting(Transform target)
    {
        Target = target;
    }


	// Update is called once per frame
	void Update ()
    {
		
	}
}
