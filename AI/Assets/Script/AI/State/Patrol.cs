using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Patrol : StateBase
{

    private GuardMain guardMain;
    public bool DetectPlayer;
    
    


    public Patrol(GuardMain guardmain) : base(guardmain.gameObject)
    {
        guardMain = guardmain;
    }

    public override Type Tick()
    {
        if (DetectPlayer == true)
        {
            return typeof(Chase);
        }
        if (guardMain.PlayerHeard == true)
        {
            return typeof(Investigate);
        }
        if(DetectPlayer == false)
        {
            guardMain.MoveToNext();
        }

        return null;
    }
 


    
}
