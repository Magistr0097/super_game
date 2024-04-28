using UnityEngine;

public class FieldOfView
{
    private readonly Mesh fieldMesh;
    private Vector3 origin;


    public FieldOfView(Mesh mesh, Vector3 origin)
    {
        fieldMesh = mesh;
        this.origin = origin;
    }

    public void RecountMeshFiled()
    {
        float fov = 90f;
        int rayCount = 50;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 10f;


        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];


        vertices[0] = origin;

        var vertexIndex = 1;
        var triangleIndex = 0;

        for (var i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), 
                viewDistance);

            if (raycastHit2D.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = raycastHit2D.point;
            }

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
    }


    private Vector3 GetVectorFromAngle(float angle)
    {
        var angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}