using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStateBase : MonoBehaviour
{
    public virtual void OnStateEnter(object o = null)
    {
        Debug.Log("OnStateEnter");
    }

    public virtual void OnStateStay()
    {
        Debug.Log("OnStateStay");
    }

    public virtual void OnStateExit()
    {
        Debug.Log("OnStateExit");
    }
}

public class StateRunning : TestStateBase
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