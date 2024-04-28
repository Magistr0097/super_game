using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MeshTest : MonoBehaviour
{
    [SerializeField] 
    public Transform pos;
    
    private FieldOfView fov;
    private Vector3 origin;
    private void Start()
    {


        
        
        
        
        
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
        
        var mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        
        fov = new FieldOfView(mesh, origin);
    }

    private void Update()
    {
        origin = pos.position;
        fov.RecountMeshFiled();
        
    }
}
