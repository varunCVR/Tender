using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudWaveEff : MonoBehaviour
{
    private Renderer rd;
    void Start()
    {
        rd = GetComponent<Renderer>();
    }

    private void Update()
    {
       rd.material.mainTextureOffset += Vector2.up * Time.deltaTime * 0.02f;
    }
}
