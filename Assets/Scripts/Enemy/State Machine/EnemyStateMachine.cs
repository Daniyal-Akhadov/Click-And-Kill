using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private Player _target;
    private State _currentState;

    public State CurrentState => _currentState;

    private void Start()
    {
        TurnOffAllTiedComponents();
        _target = GetComponent<Enemy>().Target;
        Reset(_startState);
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }

        var nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            SwitchToNextState(nextState);
        }
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }

    private void SwitchToNextState(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_target);
        }
    }

    private void TurnOffAllTiedComponents()
    {
        TurnOffAllTiedStates();
        TurnOffAllTiedTransitions();
    }

    private void TurnOffAllTiedStates()
    {
        var states = GetComponents<State>();

        foreach (var state in states)
        {
            state.enabled = false;
        }
    }

    private void TurnOffAllTiedTransitions()
    {
        var transitions = GetComponents<Transition>();

        foreach (var transition in transitions)
        {
            transition.enabled = false;
        }
    }
}
