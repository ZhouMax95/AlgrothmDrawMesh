using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour {

    public Material material;

	void Start () {
        //DrawTriangle();
        //DrawSquare();
        //DrawCircle(Vector3.zero,1,6);
        DrawAnnulus(Vector3.zero, 1f, 3f, 15);
        //DrawCube();
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
        int[] triangles = new int[side*2 * 3];
        for (int i = 0; i < side;i++)
        {
            int t0 = i * 3 + 0;
            int t1 = i * 3 + 1;
            int t2 = i * 3 + 2;

            triangles[t0] = vertices.Count - 1;
            triangles[t1] = i % side;
            triangles[t2] = (i + 1) % side;
        }
        for (int i = 0; i < side; i++)
        {
            int t0 = i * 3 + 0;
            int t1 = i * 3 + 1;
            int t2 = i * 3 + 2;

            triangles[t0+side*3] = vertices.Count - 1;
            triangles[t1 + side * 3] = (i + 1) % side;
            triangles[t2 + side * 3] =  i % side;
        }
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles;     
        MF.mesh = mesh;
        MR.material = material;
    }

    /// <summary>
    /// 画圆环
    /// </summary>
    /// <param name="coa">中心点</param>
    /// <param name="innerRadius">内环半径</param>
    /// <param name="externalRadius">外环半径</param>
    /// <param name="side">边的个数</param>
    void DrawAnnulus(Vector3 coa,float innerRadius,float externalRadius,int side)
    {
        List<Vector3> vertices = new List<Vector3>();
        for (int i = 0; i < side; i++)
        {
            float angle = Mathf.PI * 2 / side * i;
            Vector3 point = new Vector3(innerRadius * Mathf.Cos(angle) + coa.x, innerRadius * Mathf.Sin(angle) + coa.y, 0);
            vertices.Add(point);
        }
        for (int i = 0; i < side; i++)
        {
            float angle = Mathf.PI * 2 / side * i;
            Vector3 point = new Vector3(externalRadius * Mathf.Cos(angle) + coa.x, externalRadius * Mathf.Sin(angle) + coa.y, 0);
            vertices.Add(point);
        }
        GameObject go = new GameObject("Triangle");
        MeshRenderer MR = go.AddComponent<MeshRenderer>();
        MeshFilter MF = go.AddComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        int[] triangle = new int[side * 2 * 3];
        for (int i = 0; i < side; i++)
        {
            int t0 = i * 3 * 2 + 0;
            int t1 = i * 3 * 2 + 1;
            int t2 = i * 3 * 2 + 2;
            int t3 = i * 3 * 2 + 3;
            int t4 = i * 3 * 2 + 4;
            int t5 = i * 3 * 2 + 5;

            int indexV0 = i % side;
            int indexV1 = i % side + side;
            int indexV2 = (i + 1) % side + side;
            int indexV3 = (i + 1) % side;

            triangle[t0] = indexV0;
            triangle[t1] = indexV3;
            triangle[t2] = indexV1;
            triangle[t3] = indexV3;
            triangle[t4] = indexV2;
            triangle[t5] = indexV1;
        }
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangle;
        MF.mesh = mesh;
        MR.material = material;
    }

    /// <summary>
    /// 画正方体
    /// </summary>
    void DrawCube()
    {
        GameObject go = new GameObject("Cube");
        MeshRenderer MR = go.AddComponent<MeshRenderer>();
        MeshFilter MF = go.AddComponent<MeshFilter>();
        Vector3[] Vertices = { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 1, 0), new Vector3(0, 1, 0),
        new Vector3(0, 0, 1), new Vector3(1, 0, 1), new Vector3(1, 1, 1), new Vector3(0, 1, 1)};
        int[] triangle = new int[36];
        for (int i = 0; i < 4; i++)
        {
            if (i==0)
            {
                triangle[0] = 0;
                triangle[1] = 3;
                triangle[2] = 1;
                triangle[3] = 1;
                triangle[4] = 3;
                triangle[5] = 2;

                triangle[6] = 4;
                triangle[7] = 5;
                triangle[8] = 7;
                triangle[9] = 5;
                triangle[10] = 6;
                triangle[11] = 7;
            }
         
            int t0 = i % 4;
            int t1 = (i + 1) % 4;
            int t2 = (i + 1) % 4 + 4;
            int t3 = i % 4 + 4;

            int index0 = i * 6 + 0 + 12;
            int index1 = i * 6 + 1 + 12;
            int index2 = i * 6 + 2 + 12;
            int index3 = i * 6 + 3 + 12;
            int index4 = i * 6 + 4 + 12;
            int index5 = i * 6 + 5 + 12;

            triangle[index0] = t0;
            triangle[index1] = t2;
            triangle[index2] = t3;
            triangle[index3] = t0;
            triangle[index4] = t1;
            triangle[index5] = t2;
        }

        MF.mesh.vertices = Vertices;
        MF.mesh.triangles = triangle;
        MR.material = material;
    }

}
