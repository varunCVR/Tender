using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    public Material material;
    private LaserBeam beam;

    public GameObject lightOne, lightTwo,lightThree,lightFour;

    
    private void Update()
    {

        if (beam != null) 
            Destroy(beam.laserObj);
        beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material);
        
        if (beam.RayPos != null)
        {
            lightOne.transform.position = new Vector3(beam.RayPos.x, beam.RayPos.y, beam.RayPos.z);
            lightTwo.transform.position = new Vector3(beam.RayPos.x, beam.RayPos.y, beam.RayPos.z);
            lightOne.transform.eulerAngles = new Vector3( beam.RayDir.x-2f,  lightOne.transform.eulerAngles.y, lightOne.transform.eulerAngles.z);
            lightTwo.transform.eulerAngles = new Vector3( beam.RayDir.x-1f,  lightOne.transform.eulerAngles.y, lightOne.transform.eulerAngles.z);
            
            lightThree.transform.position = new Vector3(beam.RayPos.x, beam.RayPos.y, beam.RayPos.z);
            lightFour.transform.position = new Vector3(beam.RayPos.x, beam.RayPos.y, beam.RayPos.z);
            lightThree.transform.eulerAngles = new Vector3( beam.RayDir.x+1f,  lightThree.transform.eulerAngles.y, lightThree.transform.eulerAngles.z);
            lightFour.transform.eulerAngles = new Vector3( beam.RayDir.x+2f,  lightFour.transform.eulerAngles.y, lightFour.transform.eulerAngles.z);
            
        }
    }
}