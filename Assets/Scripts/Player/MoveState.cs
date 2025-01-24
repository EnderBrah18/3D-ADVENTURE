using System.Diagnostics;
using Ebac.StateMachine;
using Unity.VisualScripting;
using UnityEngine;


public class MoveState : StateBase
{
    
}

public class StateIdle : StateBase
{
    private Player player;

    public override void OnStateEnter(object o = null)
    {
        if (!player) player = GameObject.FindAnyObjectByType<Player>();
        player.SetVelocity(Vector3.zero); // Zerar o movimento
        base.OnStateEnter(o);
    }

    public override void OnStateStay()
    {
        // Não permitir movimento
        base.OnStateStay();
    }

    public override void OnStateExit()
    {
        base.OnStateExit(); // Limpar se necessário
    }
    
}

public class StateWalk : StateBase
{
    private Player player;

    public override void OnStateEnter(object o = null)
    {
        if (!player) player = GameObject.FindAnyObjectByType<Player>();
        base.OnStateEnter();
    }

    public override void OnStateStay()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        player.SetVelocity(direction * player.walkSpeed);
        

        base.OnStateStay();
    }

    public override void OnStateExit()
    {
        player.SetVelocity(Vector3.zero); // Zerar ao sair se necessário
        base.OnStateExit(); 
        
    }
}

public class StateJump : StateBase
{
    private Player player;

    public override void OnStateEnter(object o = null)
    {
        if (!player) player = GameObject.FindAnyObjectByType<Player>();
        player.Jump(); // Aplicar a força de pulo
        base.OnStateEnter(o);
    }

    public override void OnStateStay()
    {
        base.OnStateStay();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}
