using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected Player Target { get; private set; }

    public void Enter(Player target)
    {
        if (enabled == false)
        {
            Target = target;
            enabled = true;

            TurnOnTransitions();
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            TurnOffTransitions();
            enabled = false;
        }
    }

    public State GetNextState()
    {
        State result = null;
        var needTransition = GetCurrentNeedTransition();

        if (needTransition != null)
        {
            result = needTransition.TargetState;
        }

        return result;
    }

    private Transition GetCurrentNeedTransition()
    {
        Transition result = null;

        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit == true)
            {
                result = transition;
            }
        }

        return result;
    }

    private void TurnOnTransitions()
    {
        foreach (var transition in _transitions)
        {
            transition.enabled = true;
            transition.Init(Target);
        }
    }

    private void TurnOffTransitions()
    {
        foreach (var transition in _transitions)
        {
            transition.enabled = false;
        }
    }
}
