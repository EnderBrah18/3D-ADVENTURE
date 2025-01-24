using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStateMachine : MonoBehaviour
{
    public enum States
    {
        IDLE,
        RUNNING,
        JUMPING,

    }

    public Dictionary<States, TestStateBase> dictionaryState;

    private TestStateBase _currentState;
    public Player player;
    public float timeToWalk = 1f;

    private void Awake()
    {
        dictionaryState = new Dictionary<States, TestStateBase>();
        dictionaryState.Add(States.IDLE, new TestStateBase());
        dictionaryState.Add(States.RUNNING, new StateRunning());
        dictionaryState.Add(States.JUMPING, new TestStateBase());

        SwitchState(States.IDLE);

        Invoke(nameof(StartGame), timeToWalk);
    }

    private void StartGame()
    {
        SwitchState(States.RUNNING);
    }

    public void SwitchState(States state)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryState[state];

        _currentState.OnStateEnter();

    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();
    }
}
