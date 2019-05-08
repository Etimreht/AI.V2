using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine : MonoBehaviour
{
    private Dictionary<Type, StateBase> OpenStates;

    public StateBase CurrentState { get; private set; }
    public event Action<StateBase> OnChangedState;

    public  void SetStates(Dictionary<Type, StateBase> States)
    {
        OpenStates = States;
    }
    
    private void Update()
    {
        if (CurrentState == null)
        {
            CurrentState = OpenStates.Values.First();
        }


        var StateNext = CurrentState?.Tick();

        if(StateNext != null && StateNext != CurrentState?.GetType())
        {
            NewStateSwitch(StateNext);
        }
    }
    private void NewStateSwitch(Type StateNext)
    {
        CurrentState = OpenStates[StateNext];
        OnChangedState?.Invoke(CurrentState);
    }


}
