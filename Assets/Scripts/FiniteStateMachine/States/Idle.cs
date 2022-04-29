using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{

    private MovementStateMachine movementStateMachine;

    public Idle(MovementStateMachine stateMachine) : base("Idle", stateMachine)
    {
        movementStateMachine = (MovementStateMachine)stateMachine;
    }

    public override void Enter()
    {
        //base.Enter();
        //Debug.Log("MovingEnter");
        movementStateMachine

    }

    public override void UpdateLogic()
    {
        if (Input.GetKey(KeyCode.V))
        {
            movementStateMachine.ChangeState(movementStateMachine.movingState);
        }
        Debug.Log("IdleUpdateLogic");
    }
}
