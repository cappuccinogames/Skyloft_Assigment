using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager instance;
    public static CharacterManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("CharacterManager").AddComponent<CharacterManager>();
            }
            return instance;
        }
    }
    private List<CubeController> collectedCubes = new List<CubeController>();
    private CubeController tempCube;
    [SerializeField] private Transform collectedCubeParent;
    private int stackYCount, stackZCount;
    [SerializeField] private float stackOffset = 0.5f;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        stackYCount = 0;
        stackZCount = -1;
    }

    public void AddCollectedCube(CubeController _cube)
    {
        collectedCubes.Add(_cube);
        _cube.transform.parent = collectedCubeParent;
        _cube.gameObject.layer = 7;

        stackZCount++;
    }

    public Vector3 CalculateCubeTarget()
    {
        return new Vector3(0.0f, (stackYCount * ObjectPool.Instance.GetCubeYScale()) + (stackYCount * stackOffset),
            (-1f * stackZCount * ObjectPool.Instance.GetCubeZScale()) - (stackZCount * stackOffset));
    }

    public void ResetStackValues()
    {
        if (collectedCubes.Count % 3 == 0)
        {
            stackYCount++;
            stackZCount = -1;
        }
    }

    public void DecreaseCube(ref Transform _droppedPoint)
    {

        tempCube = collectedCubes[collectedCubes.Count - 1];
        collectedCubes.Remove(tempCube);
        tempCube.transform.SetParent(_droppedPoint);
        tempCube.DropCube();

        stackZCount--;

        if (collectedCubes.Count % 3 == 0)
        {
            stackYCount--;
            stackZCount = -1;
        }

    }

    public int GetCollectedCubeCount()
    {
        return collectedCubes.Count;
    }
}
