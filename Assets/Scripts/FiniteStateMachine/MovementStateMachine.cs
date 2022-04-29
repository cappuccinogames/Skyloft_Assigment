using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateMachine : StateMachine
{
    public HelperController helperController;
    [HideInInspector] public Vector3 tempVelocity;
    [SerializeField] private float speed=5f;

    [HideInInspector] public Moving movingState;
    [HideInInspector] public Idle idleState;

    public Rigidbody rigidbodyHelper;
    public float moveSpeed = 5f;

    private void Awake()
    {
        movingState = new Moving(this);
        idleState = new Idle(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
    public void GetTargetVelocity()
    {
        tempVelocity = Vector3.Normalize((helperController.GetLastCubePos()- transform.position));
    }
}
