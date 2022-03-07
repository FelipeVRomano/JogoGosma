using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("Character Points")]
    public Moviment[] jumpCharacterPoints;
    public List<GameObject> characterPoints;
    public Rigidbody2D[] physicsCharacterPoints;

    public UnityEvent OnChangeGravity;
    
    int _verticiesCount;
    Vector3[] _vertices;
    Vector3[] _normals;
    Mesh _mesh;
    
    void Awake()
    {
        _mesh = GetComponent<MeshFilter>().mesh;
        _vertices = _mesh.vertices;
        _verticiesCount = _vertices.Length;
    }
    
    void Update()
    {
        ControlCharacterPoints();
    }

    void ControlCharacterPoints()
    {
        for (int i = 0; i < _vertices.Length; i++)
        {
            _vertices[i] = characterPoints[i].transform.localPosition;
        }
        _mesh.vertices = _vertices;
    }
    
    public void JumpForAll()
    {
        for(int i = 0; i < jumpCharacterPoints.Length; i++)
        {
            jumpCharacterPoints[i].Jump();
        }
    }
    
    public void ChangeGravity(float grav)
    {
        for(int i = 0; i < physicsCharacterPoints.Length; i++)
        {
            physicsCharacterPoints[i].gravityScale = grav;
        }
        OnChangeGravity.Invoke();
    }
}
