using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private BakeNavMesh bakeNavMesh;
    [SerializeField] private MazeSpawner mazeSpawner;
    void Awake()
    {
        instance = this;
    }
    public void Bake()
    {
        bakeNavMesh.Bake();
    }
}
