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
        player = (Player)o;
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
