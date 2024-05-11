using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class MeshTest : MonoBehaviour
{
    [SerializeField]
    private Transform pos;
    [SerializeField]
    private FieldOfView fov;

    private AINavigation Navigation;
    
    private void Start()
    {
        Navigation = GetComponent<AINavigation>();
        fov.SetFovAngle(60);
    }

    private void Update()
    {
        fov.SetOrigin(pos.position);
        fov.SetFovDirection(Navigation.rotation);
    }

    public bool IsPlayerVisible()
    {
        return fov.IsPlayerVisible();
    }
}

// var myMesh = new Mesh();
//
// var vertices = new Vector3[3];
// var uv = new Vector2[3];
// var triangles = new int[3];
//
// vertices[0] = new Vector3(0, 0);
// vertices[1] = new Vector3(0, 10);
// vertices[2] = new Vector3(10, 10);
//
// // По часовой - передняя часть Против - задняя
//
// triangles[0] = 0;
// triangles[1] = 1;
// triangles[2] = 2;
//
// uv[0] = new Vector2(1, 0);
// uv[1] = new Vector2(0, 1);
// uv[2] = new Vector2(1, 1);
//
// myMesh.vertices = vertices;
// myMesh.uv = uv;
// myMesh.triangles = triangles;
//
//
// GetComponent<MeshFilter>().mesh = myMesh;