using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BakeNavMesh : MonoBehaviour
{
    [SerializeField] NavMeshSurface navMeshSurface;
    
    public void Bake()
    {
        StartCoroutine(WaitToBake());
    }

    IEnumerator WaitToBake()
    {
        yield return new WaitForSeconds(2f);
        navMeshSurface.BuildNavMesh();
    }
  
}
