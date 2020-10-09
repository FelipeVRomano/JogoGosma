using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoMolenga : MonoBehaviour
{
    public Mesh mesh;
    public Vector3[] vertices;
    public Vector3[] normals;
    public int CenterPoint;
    public int verticiesCount;


    public Movimento[] pulou;
    public List<GameObject> points;
    public GameObject toBeIstantiated;
    public Rigidbody2D[] gosminha;

    bool controle;
    int contador;

    public float x;
    // Start is called before the first frame update
    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        verticiesCount = vertices.Length;

    }


    // Update is called once per frame
    void Update()
    {
      
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = points[i].transform.localPosition;
        }
        mesh.vertices = vertices;
    }

    public void JumpForAll()
    {
        for(int i = 0; i < pulou.Length; i++)
        {
            pulou[i].Jump();
        }
    }
    public void mudaGrav(float grav)
    {
        for(int i = 0; i < gosminha.Length; i++)
        {
            gosminha[i].gravityScale = grav;
        }
    }
}
