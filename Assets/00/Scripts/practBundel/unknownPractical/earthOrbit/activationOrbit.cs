 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activationOrbit : MonoBehaviour
{
    [Header("Confirmation Area")] 
    public bool polar;
    public bool geost;
    public bool geosy;

    public bool polar_pathway;
    public bool geost_pathway;
    public bool geosy_pathway;

    public bool polar_PS;
    public bool geost_PS;
    public bool geosy_PS;

    public bool _3ddetail_Polar;
    public bool _3ddetail_geost;
    public bool _3ddetail_geosy;
    
    [Header("Polar Orbit")] public GameObject smallPolar;
    public GameObject polarMain1;
    public GameObject polarLine1;
    public ParticleSystem polarPS1;
    public GameObject polarMain2;
    public GameObject polarLine2;
    public ParticleSystem polarPS2;

    [Header("Geostationary Orbit")] public GameObject smallGst;
    public GameObject geostMain;
    public GameObject geostLine;
    public ParticleSystem geostPS;

    [Header("Geosynchronous Orbit")] public GameObject smallGsy;
    public GameObject geosyMain;
    public GameObject geosyLine;
    public ParticleSystem geosyPS;

    [Space] public GameObject activater;
    public bool onofBool;

    [Header("3D detail Area")] 
    public GameObject _detailPolar1;
    public GameObject _detailPolar2;
    public GameObject _detailGeost;
    public GameObject _detailGeosy;

    public void orbitTypes()
    {
        onofBool =! onofBool;
    }

    private void Update()
    {
        if (activater.activeInHierarchy != onofBool) {
            activater.SetActive(onofBool);
        }

        if (onofBool)
        {
            if (polar && !polarLine2.activeInHierarchy) {
                smallPolar.SetActive(true);
                polarMain1.SetActive(true);
                polarMain2.SetActive(true);
            }

            if (geost && !geostMain.activeInHierarchy) {
                smallGst.SetActive(true);
                geostMain.SetActive(true);
            }

            if (geosy && !geosyMain.activeInHierarchy) {
                smallGsy.SetActive(true);
                geosyMain.SetActive(true);
            }

            if (polar_pathway && !polarLine2.activeInHierarchy) {
                polarLine1.SetActive(true);
                polarLine2.SetActive(true);
            }

            if (geost_pathway && !geostLine.activeInHierarchy)
                geostLine.SetActive(true);

            if (geosy_pathway && !geosyLine.activeInHierarchy)
                geosyLine.SetActive(true);

            if (polar_PS && !polarPS2.isPlaying) {
                polarPS1.Play();
                polarPS2.Play();
            }

            if (geost_PS && !geostPS.isPlaying)
                geostPS.Play();
            
            if (geosy_PS && !geosyPS.isPlaying)
                geosyPS.Play();

            if (_3ddetail_Polar && !_detailPolar2.activeInHierarchy ) {
                _detailPolar1.SetActive(true);
                _detailPolar2.SetActive(true);
            }
            
            if (_3ddetail_geost && !_detailGeost.activeInHierarchy)
                _detailGeost.SetActive(true);
            
            if (_3ddetail_geosy && !_detailGeosy.activeInHierarchy)
                _detailGeosy.SetActive(true);
        }
        else
        {
            if (polar && polarLine2.activeInHierarchy) {
                smallPolar.SetActive(false);
                polarMain1.SetActive(false);
                polarMain2.SetActive(false);
            }

            if (geost && geostMain.activeInHierarchy)
            {
                smallGst.SetActive(false);
                geostMain.SetActive(false);
            }

            if (geosy && geosyMain.activeInHierarchy)
            {
                smallGsy.SetActive(false);
                geosyMain.SetActive(false);
            }

            if (polar_pathway && polarLine2.activeInHierarchy) {
                polarLine1.SetActive(false);
                polarLine2.SetActive(false);
            }

            if (geost_pathway && geostLine.activeInHierarchy)
                geostLine.SetActive(false);

            if (geosy_pathway && geostLine.activeInHierarchy)
                geosyLine.SetActive(false);

            if (polar_PS && !polarPS2.isStopped) {
                polarPS1.Stop();
                polarPS2.Stop();
            }

            if (geost_PS && !geostPS.isStopped)
                geostPS.Stop();

            if (geosy_PS && !geosyPS.isStopped)
                geosyPS.Stop();
            
            if (_3ddetail_Polar && _detailPolar2.activeInHierarchy ) {
                _detailPolar1.SetActive(false);
                _detailPolar2.SetActive(false);
            }
            
            if (_3ddetail_geost && _detailGeost.activeInHierarchy)
                _detailGeost.SetActive(false);
            
            if (_3ddetail_geosy && _detailGeosy.activeInHierarchy)
                _detailGeosy.SetActive(false);
        }
    }
}
