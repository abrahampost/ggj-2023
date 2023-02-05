using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.AI;
// using NavMeshComponents;

public class NavMeshBaker : MonoBehaviour {
    void Start () 
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }

}