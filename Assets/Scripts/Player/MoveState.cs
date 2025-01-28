using System.Diagnostics;
using Ebac.StateMachine;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Playables;


public class MoveState : StateBase
{
    
}

public class StateIdle : StateBase
{
    private Player player;

    public override void OnStateEnter(object o = null)
    {
        if (!player) player = GameObject.FindAnyObjectByType<Player>();
        player.animator.SetBool("Run", false);

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
    private Movement movement;

    public override void OnStateEnter(object o = null)
    {
        if (!player) player = GameObject.FindAnyObjectByType<Player>();
        if (!movement) movement = GameObject.FindAnyObjectByType<Movement>();
        player.animator.SetBool("Run", true);
        base.OnStateEnter();
    }

    public override void OnStateStay()
    {
        
        // Obter os valores de entrada
        float inputAxisHorizontal = Input.GetAxis("Horizontal");
        float inputAxisVertical = Input.GetAxis("Vertical");

        // Determinar a direção desejada pelo jogador
        Vector3 inputDirection = new Vector3(inputAxisHorizontal, 0, inputAxisVertical);

        // Se houver alguma entrada, rotaciona o personagem na direção da entrada
        if (inputDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, player.turnSpeed * Time.deltaTime);
        }

        if (player.characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.vSpeed = player.jumpSpeed;
            }
        }



        // Calcula o movimento baseado na direção que o personagem está olhando
        var speedVector = player.transform.forward * inputDirection.magnitude * player.speed;


        // Aplica a gravidade
        player.vSpeed -= player.gravity * Time.deltaTime;
        speedVector.y = player.vSpeed;

        // Move o CharacterController
        player.characterController.Move(speedVector * Time.deltaTime);

        if (Mathf.Approximately(Input.GetAxis("Horizontal"), 0) &&
         Mathf.Approximately(Input.GetAxis("Vertical"), 0) )
        {
            movement.stateMachine.SwitchState(Movement.MovementStates.IDLE);


        }

        base.OnStateStay();

        
    
    }

    public override void OnStateExit()
    {
        
        base.OnStateExit(); 
        
    }
}

public class StateJump : StateBase
{
    private Player player;
    private Movement movement;

    public override void OnStateEnter(object o = null)
    {
       
    

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
