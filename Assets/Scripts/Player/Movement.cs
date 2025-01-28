using System.Collections;
using System.Collections.Generic;
using Ebac.Core.Singleton;
using Ebac.StateMachine;
using UnityEngine;
using UnityEngine.Playables;

public class Movement : Singleton<Movement>
{
    public enum MovementStates
    {
        WALK,
        JUMP,
        IDLE,
    }

    public StateMachine<MovementStates> stateMachine;
    public Player player;
    public float timeToWalk = 1f;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        stateMachine = new StateMachine<MovementStates>();
        stateMachine.Init();
        stateMachine.RegisterStates(MovementStates.IDLE, new StateIdle());
        stateMachine.RegisterStates(MovementStates.WALK, new StateWalk());
        stateMachine.RegisterStates(MovementStates.JUMP, new StateJump());

        stateMachine.SwitchState(MovementStates.IDLE);

    }

    void Update()
    {
        stateMachine.Update();

        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.Space))))))
        {
            stateMachine.SwitchState(MovementStates.WALK);
        }
        
        



    }
 }
