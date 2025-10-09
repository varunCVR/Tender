using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSimulater : MonoBehaviour
{
    Mesh mesh;
    Vector3[] verts;
    MeshCollider meshCol;

    public float SinValu;
    public float hightReacher;
    public float waveSpeed;
    private void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        verts = mesh.vertices;
        meshCol = GetComponent<MeshCollider>();
    }

    private void Update()
    {
        for (int i = 0; i < verts.Length; i++)
        {
            verts[i].y = Mathf.Sin(SinValu * i + Time.time * waveSpeed) * hightReacher;
        }
        mesh.vertices = verts;
        mesh.RecalculateBounds();
        meshCol.sharedMesh = mesh;
    }
}
