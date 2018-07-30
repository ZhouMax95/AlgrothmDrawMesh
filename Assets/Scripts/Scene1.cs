using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour {

    public Material material;

	void Start () {
        //DrawTriangle();
        DrawSquare();
    }
	
	
	void Update () {
		
	}


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

    void DrawCircle(Vector3 coc,float radius,int side)
    {
        List<Vector3> vertices = new List<Vector3>();
        for (int i = 0; i < side; i++)
        {

        }
    }
}
