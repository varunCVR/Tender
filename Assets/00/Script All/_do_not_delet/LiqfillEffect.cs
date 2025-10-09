    using UnityEngine;
public class LiqfillEffect : MonoBehaviour
{
    public Renderer shaderRD;                           // renderer object...
    public downer bickerSize;                           // liq Type DropDown
    public callType callmethod;                         // start or update
    public fillType fillMethod = fillType.Null;         // num of auto
    
    
    // if it is num..... 
    [Range(0,100)]
    public float fillFloat_100ml;
    [Range(0,250)]
    public float fillFloat_250ml;
    [Range(0,500)]
    public float fillFloat_500ml;
    
    //if it is auto.......
    public liqRange liqFillArea;
        
    public bool ColorChange;
    public bool updateColor;
    
    
    
    public Color desiredColor;

    
    public enum downer
    {
        none,
        ml_500,
        ml_250,
        ml_100,
    }
    public enum callType
    {
        StartMethod,
        UpdateMethod
    }
    public enum fillType
    {
        Null,
        Autometic,
        Numerical
    }
    public enum liqRange
    {
        firstStep,
        secStep,
        Half,
        secHalf,
        full,
    }
    private void Start()
    {
        if (ColorChange)
        {
            shaderRD.material.SetColor("_LCol",desiredColor);
            shaderRD.material.SetColor("_SCol",desiredColor);
        }
        
        if (callmethod == callType.StartMethod)
        {
            if (fillMethod == fillType.Autometic)
            { 
                if (bickerSize == downer.ml_500)
                { if (liqFillArea == liqRange.firstStep) { shaderRD.material.SetFloat("_Fill", 0.0256f); }
                     if (liqFillArea == liqRange.secStep) { shaderRD.material.SetFloat("_Fill", 0.0485f); }
                     if (liqFillArea == liqRange.Half) { shaderRD.material.SetFloat("_Fill", 0.0707f); }
                     if (liqFillArea == liqRange.secHalf) { shaderRD.material.SetFloat("_Fill", 0.0929f); }
                     if (liqFillArea == liqRange.full) { shaderRD.material.SetFloat("_Fill", 0.1157f); }
                }
                if (bickerSize == downer.ml_250)
                {
                    if (liqFillArea == liqRange.firstStep) { shaderRD.material.SetFloat("_Fill", 0.0195f); }
                    if (liqFillArea == liqRange.secStep) { shaderRD.material.SetFloat("_Fill", 0.037f); }
                    if (liqFillArea == liqRange.Half) { shaderRD.material.SetFloat("_Fill", 0.0545f); }
                    if (liqFillArea == liqRange.secHalf) { shaderRD.material.SetFloat("_Fill", 0.072f); }
                    if (liqFillArea == liqRange.full) { shaderRD.material.SetFloat("_Fill", 0.0895f); }
                }
                if (bickerSize == downer.ml_100) {
                    if (liqFillArea == liqRange.firstStep) { shaderRD.material.SetFloat("_Fill", 0.0152f); }
                    if (liqFillArea == liqRange.secStep) { shaderRD.material.SetFloat("_Fill", 0.0277f); }
                    if (liqFillArea == liqRange.Half) {shaderRD.material.SetFloat("_Fill", 0.0398f); }
                    if (liqFillArea == liqRange.secHalf) { shaderRD.material.SetFloat("_Fill", 0.052f); }
                    if (liqFillArea == liqRange.full) { shaderRD.material.SetFloat("_Fill", 0.0645f); }
                }
            }
            if (fillMethod == fillType.Numerical) {
                if (bickerSize == downer.ml_500) {
                    counterML500();
                }
                if (bickerSize == downer.ml_250) {
                    counterML250();
                }
                if (bickerSize == downer.ml_100) {
                    counterML100();
                }
            }
        }
    }
    void counterML100() {
        float filler = 0.000645f;
        float realFill = fillFloat_100ml * filler;
        shaderRD.material.SetFloat("_Fill",realFill);
    }
    void counterML250() {
        float filler = 0.000358f;
        float realFill = fillFloat_250ml * filler;
        shaderRD.material.SetFloat("_Fill",realFill);
    }
    void counterML500() {
        float filler = 0.0002314f;
        float realFill = fillFloat_500ml * filler;
        shaderRD.material.SetFloat("_Fill",realFill);
    }
    private void Update()
    {
        if (updateColor)
        {
            shaderRD.material.SetColor("_LCol",desiredColor);
            shaderRD.material.SetColor("_SCol",desiredColor);
        }
        
        
       if (callmethod == callType.UpdateMethod)
       {
            if (fillMethod == fillType.Autometic)
            { 
                if (bickerSize == downer.ml_500)
                { if (liqFillArea == liqRange.firstStep) { shaderRD.material.SetFloat("_Fill", 0.0256f); }
                     if (liqFillArea == liqRange.secStep) { shaderRD.material.SetFloat("_Fill", 0.0485f); }
                     if (liqFillArea == liqRange.Half) { shaderRD.material.SetFloat("_Fill", 0.0707f); }
                     if (liqFillArea == liqRange.secHalf) { shaderRD.material.SetFloat("_Fill", 0.0929f); }
                     if (liqFillArea == liqRange.full) { shaderRD.material.SetFloat("_Fill", 0.1157f); }
                }
                if (bickerSize == downer.ml_250)
                {
                    if (liqFillArea == liqRange.firstStep) { shaderRD.material.SetFloat("_Fill", 0.0195f); }
                    if (liqFillArea == liqRange.secStep) { shaderRD.material.SetFloat("_Fill", 0.037f); }
                    if (liqFillArea == liqRange.Half) { shaderRD.material.SetFloat("_Fill", 0.0545f); }
                    if (liqFillArea == liqRange.secHalf) { shaderRD.material.SetFloat("_Fill", 0.072f); }
                    if (liqFillArea == liqRange.full) { shaderRD.material.SetFloat("_Fill", 0.0895f); }
                }
                if (bickerSize == downer.ml_100) {
                    if (liqFillArea == liqRange.firstStep) { shaderRD.material.SetFloat("_Fill", 0.0152f); }
                    if (liqFillArea == liqRange.secStep) { shaderRD.material.SetFloat("_Fill", 0.0277f); }
                    if (liqFillArea == liqRange.Half) {shaderRD.material.SetFloat("_Fill", 0.0398f); }
                    if (liqFillArea == liqRange.secHalf) { shaderRD.material.SetFloat("_Fill", 0.052f); }
                    if (liqFillArea == liqRange.full) { shaderRD.material.SetFloat("_Fill", 0.0645f); }
                }
            }
            if (fillMethod == fillType.Numerical)
            {
                if (bickerSize == downer.ml_500)
                {
                    counterML500();
                }
                if (bickerSize == downer.ml_250)
                {
                    counterML250();
                }
                if (bickerSize == downer.ml_100)
                {
                    counterML100();
                }
            }
       }
    } 
}

