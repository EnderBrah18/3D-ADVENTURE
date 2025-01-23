using Ebac.StateMachine;


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
        player.canMove = true;
        base.OnStateEnter();

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
