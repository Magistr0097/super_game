using System;
using JetBrains.Annotations;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField]
    private LayerMask collideLayerMask;
    
    private Mesh fieldMesh;
    private MeshFilter meshFilter;
    private Vector3 origin;
    private RaycastHit2D raycastHit2D;
    
    private float fovAngle;
    private float fovDistance;
    private float startAngle;

    
    private void Start()
    {
        fieldMesh = new Mesh();
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = fieldMesh;
        origin = Vector3.zero;
        fovAngle = 90f;
        fovDistance = 10f;
        startAngle = 0f;
    }

    public void LateUpdate()
    {
        int rayCount = 50;
        float angle = startAngle;
        float angleIncrease = fovAngle / rayCount;
        
        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        var vertexIndex = 1;
        var triangleIndex = 0;

        for (var i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            
            raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), 
                fovDistance, collideLayerMask);
            
            if (raycastHit2D.collider == null)
                vertex = origin + GetVectorFromAngle(angle) * fovDistance;
            
            else
                vertex = raycastHit2D.point;
            

            vertices[vertexIndex] = vertex;
            
            if (i > 0)
            {
                triangles[triangleIndex] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                
                triangleIndex += 3;
            }
            
            angle -= angleIncrease;
            vertexIndex++;
        }


        fieldMesh.vertices = vertices;
        fieldMesh.triangles = triangles;
        fieldMesh.uv = uv;
        fieldMesh.bounds = new Bounds(origin, Vector3.one * 1000f);
    }

    public void SetFovDirection(float fovDirection)
    {
        startAngle = (55 + fovDirection) - fovAngle / 2f;
    }
    
    public void SetOrigin(Vector3 newOrigin)
    {
        origin = newOrigin;
        // Debug.Log($"{origin.x}, {origin.y}, {origin.z}");
    }
    
    public void SetFovAngle(float angle)
    {
        fovAngle = angle;
    }
    
    public void SetFovDistance(float distance)
    {
        fovDistance = distance;
    }
    
    [CanBeNull]
    public string GetFovColliderTag()
    {
        return raycastHit2D.collider.tag;
    }

    private static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Debug.Log($"{dir.y} {dir.x} {Mathf.Atan2(dir.y, dir.x)}");
        if (n < 0)
            n += 360;
        return n;
    }
    
    private Vector3 GetVectorFromAngle(float angle)
    {
        var angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}