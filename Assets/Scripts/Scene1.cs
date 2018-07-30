using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour {

    public Material material;

	void Start () {
        //DrawTriangle();
        //DrawSquare();
        DrawCircle(Vector3.zero,1,40);
    }
	
	
	void Update () {
		
	}

    /// <summary>
    /// 画三角型
    /// </summary>
    void DrawTriangle()
    {
        GameObject go = new GameObject("Triangle");
        MeshRenderer MR = go.AddComponent<MeshRenderer>();
        MeshFilter MF = go.AddComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        Vector3[] vertices = { new Vector3(0, 0, 0), new Vector3(0, 2, 0), new Vector3(2, 0, 0) };
        mesh.vertices = vertices;
        int[] triangle = { 0, 1, 2 };
        mesh.triangles = triangle;
        MR.material = material;
        MF.mesh = mesh;
       
    }

    /// <summary>
    /// 画正方形()
    /// </summary>
    void DrawSquare()
    {
        GameObject go = new GameObject("Triangle");
        MeshRenderer MR = go.AddComponent<MeshRenderer>();
        MeshFilter MF = go.AddComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        Vector3[] vertices = { new Vector3(0, 0, 0), new Vector3(0, 2, 0), new Vector3(2, 0, 0),new Vector3(2,2,0) };
        mesh.vertices = vertices;
        int[] triangle = { 0, 1, 2, 1, 3, 2, 0, 2, 1, 1, 2, 3 };
        mesh.triangles = triangle;
        MR.material = material;
        MF.mesh = mesh;
    }

    /// <summary>
    /// 画圆
    /// </summary>
    /// <param name="coc"></param>
    /// <param name="radius"></param>
    /// <param name="side"></param>
    void DrawCircle(Vector3 coc,float radius,int side)
    {
        List<Vector3> vertices = new List<Vector3>();
        for (int i = 0; i < side; i++)
        {
            float angle = (2*Mathf.PI / side) * i;
            Vector3 pointOfSide = new Vector3(radius * Mathf.Cos(angle) + coc.x, radius * Mathf.Sin(angle) + coc.y, 0);
            vertices.Add(pointOfSide);
        }
        vertices.Add(coc);
        GameObject go = new GameObject("Triangle");
        MeshRenderer MR = go.AddComponent<MeshRenderer>();
        MeshFilter MF = go.AddComponent<MeshFilter>();
        Mesh mesh = new Mesh();  
        int[] triangles = new int[side * 3];
        for (int i = 0; i < side;i++)
        {
            int t0 = i * 3 + 0;
            int t1 = i * 3 + 1;
            int t2 = i * 3 + 2;

            int vIndex1 = i % side;
            int vIndex2 = i + 1 % side;
            triangles[t0] = vertices.Count - 1;
            triangles[t1] = i % side;
            triangles[t2] = i + 1 % side;
        }
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles;     
        MF.mesh = mesh;
        MR.material = material;
    }
}
