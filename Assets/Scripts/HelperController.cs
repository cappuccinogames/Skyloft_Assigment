using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperController : MonoBehaviour
{
    
    public MovementStateMachine movementStateMachine;
    [SerializeField] private Animator helperAnimator;

    [SerializeField] private List<CubeController> targetCubes = new List<CubeController>();

    public void SetTargetCubes(List<CubeController> _cubes)
    {
        targetCubes = _cubes;
    }
    public Vector3 GetLastCubePos()
    {
        return targetCubes[targetCubes.Count - 1].transform.position;
    }
    public void PlayWalkAnimation()
    {
        helperAnimator.SetBool("IsWalking",true);
    }
    public void PlayIdleAnimation()
    {
        helperAnimator.SetBool("IsWalking", false);
    }
}
