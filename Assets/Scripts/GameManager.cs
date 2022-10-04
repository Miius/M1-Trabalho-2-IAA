using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private MazeSpawner mazeSpawner;

    [SerializeField] private Transform playerTarget;
    [SerializeField] private Transform scapeTarget;
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach (var navMeshMoviment in FindObjectsOfType<NavMeshMoviment>())
            navMeshMoviment.ReciveTarget(scapeTarget);
    }
}
