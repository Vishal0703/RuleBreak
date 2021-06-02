using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
	private IState currentState;
	private Dictionary<Type, List<Transition>> transitions = new Dictionary<Type, List<Transition>>();
    private List<Transition> anyTransitions = new List<Transition>();
    private List<Transition> currentTransitions = new List<Transition>();
    private static List<Transition> emptyTransitions = new List<Transition>(0);

    public void Tick()
    {
        var transition = GetTransition();
        if(transition != null)
        {
            SetState(transition.to);
        }

        currentState?.Tick();
    }

    public void LateTick()
    {
        currentState?.LateTick();
    }

    public void FixedTick()
    {
        currentState?.FixedTick();
    }

    private Transition GetTransition()
    {
        foreach(var transition in anyTransitions)
        {
            if (transition.Condition())
                return transition;
        }

        foreach(var transition in currentTransitions)
        {
            if (transition.Condition())
                return transition;
        }
        return null;
    }

    public void SetState(IState state)
    {
        if (state == currentState)
            return;

        currentState?.OnStateExit(); //exit previous state
        currentState = state;

        transitions.TryGetValue(currentState.GetType(), out currentTransitions);
        if(currentTransitions == null)
        {
            currentTransitions = emptyTransitions;
        }

        currentState?.OnStateEnter(); //enter new state
    }


    public void AddTransition(IState from, IState to, Func<bool> Predicate)
    {
        if (!transitions.TryGetValue(from.GetType(), out var transitionList))
        {
            transitionList = new List<Transition>();
            transitions[from.GetType()] = transitionList;
        }
        transitionList.Add(new Transition(to, Predicate));
    }
    private class Transition
    {
        public Func<bool> Condition;
        public IState to;
		public Transition(IState _to, Func<bool> _Condition)
        {
            to = _to;
            Condition = _Condition;
        }
    }
}
