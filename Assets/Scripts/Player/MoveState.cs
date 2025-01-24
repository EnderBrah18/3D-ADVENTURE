using System.Diagnostics;
using Ebac.StateMachine;
using Unity.VisualScripting;
using UnityEngine;


public class MoveState : StateBase
{
    
}

public class StateIdle : StateBase
{

}

public class StateWalk : StateBase
{
    public Player player;
    public override void OnStateEnter(object o = null)
    {

        // Cache this one and only fetch it again when needed
        if (!player) player = Player.FindAnyObjectByType<Player>();


        player.canMove = true;
        base.OnStateEnter(o);

    }

    public override void OnStateExit()
    {
        player.canMove = false;
        base.OnStateExit();
    }
}

public class StateJump : StateBase
{

}
