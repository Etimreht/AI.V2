using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMain : MonoBehaviour
{
    public Transform Target { get; private set; }
    public StateMachine StateMachine;
    public float speed;
    public bool PlayerHeard = false;
    public Transform[] MovePoints;
    
    public int TargetPoint;

    // Use this for initialization
    private void Awake ()
    {
        IntializeStateMachine();
	}
	
    private void IntializeStateMachine()
    {
        var StateList = new Dictionary<Type, StateBase>()
        {
            { typeof(Patrol), new Patrol(guardmain: this) },
            { typeof(Chase), new Chase(guardmain: this) },
            { typeof(Investigate), new Investigate(guardmain: this) }
            
        };

        GetComponent<StateMachine>().SetStates(StateList);
    }

    public void MoveToNext()
    {
        if (MovePoints.Length == 0)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, MovePoints[TargetPoint].position, (speed * Time.deltaTime));
        if (transform.position == MovePoints[TargetPoint].position)
        {
            transform.eulerAngles = Vector3.RotateTowards(transform.position, MovePoints[TargetPoint].position, (speed * Time.deltaTime), 0f);
            TargetPoint = (TargetPoint + 1) % MovePoints.Length;

        }


    }
    public void Targeting(Transform target)
    {
        Target = target;
    }


	// Update is called once per frame
	void Update ()
    {
        Debug.Log(StateMachine.CurrentState);
	}
}
