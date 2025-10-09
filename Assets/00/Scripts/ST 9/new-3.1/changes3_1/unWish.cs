using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unWish : MonoBehaviour
{
    public enum myEnum
    {
        water2,water3,water4,respown2,respown3,respown4
    }

    public myEnum define;
    public Renderer fillArea;
    private void OnTriggerExit(Collider other)
    {
        if (define == myEnum.water2)
        {
            if (other.CompareTag("water2"))
            {
                fillArea.material.SetFloat("_Fill",0.532f);
                Destroy(gameObject,0.1f);
            }
        }
        if (define == myEnum.water3)
        {
            if (other.CompareTag("water3"))
            {
                fillArea.material.SetFloat("_Fill",0.532f);
                Destroy(gameObject,0.1f);
            }
            
        }

        if (define == myEnum.water4)
        {
            if (other.CompareTag("water4"))
            {
                fillArea.material.SetFloat("_Fill",0.54f);
                Destroy(gameObject,0.1f);
            }
        }

        if (define == myEnum.respown2)
        {
            if (other.CompareTag("Respawn2"))
            {
                fillArea.material.SetFloat("_Fill",0.534f);
                Destroy(gameObject,0.1f);
            }
        }

        if (define == myEnum.respown3)
        {
            if (other.CompareTag("Respawn3"))
            {
                fillArea.material.SetFloat("_Fill",0.535f);
                Destroy(gameObject,0.1f);
            }
        }

        if (define == myEnum.respown4)
        {
            if (other.CompareTag("Respawn4"))
            {
                fillArea.material.SetFloat("_Fill",0.53f);
                Destroy(gameObject,0.1f);
            }
        }
    }
    
}
