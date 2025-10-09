using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnHndler : MonoBehaviour
{
    public GameObject convex, concve, convexLens, concaveLens, Prism;

    private void Start()
    {
        LoadPrism();
    }

    public void LoadConvex()
    {
     
        concve.SetActive(false);
        convexLens.SetActive(false);
        concaveLens.SetActive(false);
        Prism.SetActive(false);
        convex.SetActive(true);
    }
    public void LoadConve()
    {
        convex.SetActive(false);
       
        convexLens.SetActive(false);
        concaveLens.SetActive(false);
        Prism.SetActive(false);
        concve.SetActive(true);
    }
    public void LoadConvexLens()
    {
        convex.SetActive(false);
        concve.SetActive(false);
       
        concaveLens.SetActive(false);
        Prism.SetActive(false);
        convexLens.SetActive(true);
    }
    public void LoadConcaveLens()
    {
        convex.SetActive(false);
        concve.SetActive(false);
        convexLens.SetActive(false);
        
        Prism.SetActive(false);
        concaveLens.SetActive(true);
    }
    public void LoadPrism()
    {
        convex.SetActive(false);
        concve.SetActive(false);
        convexLens.SetActive(false);
        concaveLens.SetActive(false);
        Prism.SetActive(true);
    }
}
