using UnityEngine;

public class fillSetter : MonoBehaviour
{
    [Header("**Fill style**")] public bool automatic;
    public bool numeric;

    [Header("fill Type")] public bool startMethod;
    public bool updateMethod;
    public downer LiqMl;
    [Space] [Range(0, 100)] public int fillFloat_100ml;
    [Range(0, 250)] public int fillFloat_250ml;
    [Range(0, 500)] public int fillFloat_500ml;


    public enum downer
    {
        ml_500,
        ml_250,
        ml_100
    }

    public enum liqRange
    {
        firstStep,
        secStep,
        Half,
        secHalf,
        full
    }

    public liqRange liqFillArea;

    public Renderer shaderRD;

    private void Start()
    {
        if (automatic)
            if (startMethod)
            {
                if (LiqMl == downer.ml_500)
                {
                    if (liqFillArea == liqRange.firstStep) shaderRD.material.SetFloat("_Fill", 0.0256f);
                    if (liqFillArea == liqRange.secStep) shaderRD.material.SetFloat("_Fill", 0.0485f);
                    if (liqFillArea == liqRange.Half) shaderRD.material.SetFloat("_Fill", 0.0707f);
                    if (liqFillArea == liqRange.secHalf) shaderRD.material.SetFloat("_Fill", 0.0929f);
                    if (liqFillArea == liqRange.full) shaderRD.material.SetFloat("_Fill", 0.1157f);
                }

                if (LiqMl == downer.ml_250)
                {
                    if (liqFillArea == liqRange.firstStep) shaderRD.material.SetFloat("_Fill", 0.0195f);
                    if (liqFillArea == liqRange.secStep) shaderRD.material.SetFloat("_Fill", 0.037f);
                    if (liqFillArea == liqRange.Half) shaderRD.material.SetFloat("_Fill", 0.0545f);
                    if (liqFillArea == liqRange.secHalf) shaderRD.material.SetFloat("_Fill", 0.072f);
                    if (liqFillArea == liqRange.full) shaderRD.material.SetFloat("_Fill", 0.0895f);
                }

                if (LiqMl == downer.ml_100)
                {
                    if (liqFillArea == liqRange.firstStep) shaderRD.material.SetFloat("_Fill", 0.0152f);
                    if (liqFillArea == liqRange.secStep) shaderRD.material.SetFloat("_Fill", 0.0277f);
                    if (liqFillArea == liqRange.Half) shaderRD.material.SetFloat("_Fill", 0.0398f);
                    if (liqFillArea == liqRange.secHalf) shaderRD.material.SetFloat("_Fill", 0.052f);
                    if (liqFillArea == liqRange.full) shaderRD.material.SetFloat("_Fill", 0.0645f);
                }
            }


        if (numeric)
            if (startMethod)
            {
                if (LiqMl == downer.ml_500) counterML500();
                if (LiqMl == downer.ml_250) counterML250();
                if (LiqMl == downer.ml_100) counterML100();
            }
    }

    private void counterML100()
    {
        var filler = 0.000645f;
        var realFill = fillFloat_100ml * filler;
        shaderRD.material.SetFloat("_Fill", realFill);
    }

    private void counterML250()
    {
        var filler = 0.000358f;
        var realFill = fillFloat_250ml * filler;
        shaderRD.material.SetFloat("_Fill", realFill);
    }

    private void counterML500()
    {
        var filler = 0.0002314f;
        var realFill = fillFloat_500ml * filler;
        shaderRD.material.SetFloat("_Fill", realFill);
    }


    private void Update()
    {
        if (automatic)
            if (updateMethod)
            {
                if (LiqMl == downer.ml_500)
                {
                    if (liqFillArea == liqRange.firstStep) shaderRD.material.SetFloat("_Fill", 0.0256f);
                    if (liqFillArea == liqRange.secStep) shaderRD.material.SetFloat("_Fill", 0.0485f);
                    if (liqFillArea == liqRange.Half) shaderRD.material.SetFloat("_Fill", 0.0707f);
                    if (liqFillArea == liqRange.secHalf) shaderRD.material.SetFloat("_Fill", 0.0929f);
                    if (liqFillArea == liqRange.full) shaderRD.material.SetFloat("_Fill", 0.1157f);
                }

                if (LiqMl == downer.ml_250)
                {
                    if (liqFillArea == liqRange.firstStep) shaderRD.material.SetFloat("_Fill", 0.0195f);
                    if (liqFillArea == liqRange.secStep) shaderRD.material.SetFloat("_Fill", 0.037f);
                    if (liqFillArea == liqRange.Half) shaderRD.material.SetFloat("_Fill", 0.0545f);
                    if (liqFillArea == liqRange.secHalf) shaderRD.material.SetFloat("_Fill", 0.072f);
                    if (liqFillArea == liqRange.full) shaderRD.material.SetFloat("_Fill", 0.0895f);
                }

                if (LiqMl == downer.ml_100)
                {
                    if (liqFillArea == liqRange.firstStep) shaderRD.material.SetFloat("_Fill", 0.0152f);
                    if (liqFillArea == liqRange.secStep) shaderRD.material.SetFloat("_Fill", 0.0277f);
                    if (liqFillArea == liqRange.Half) shaderRD.material.SetFloat("_Fill", 0.0398f);
                    if (liqFillArea == liqRange.secHalf) shaderRD.material.SetFloat("_Fill", 0.052f);
                    if (liqFillArea == liqRange.full) shaderRD.material.SetFloat("_Fill", 0.0645f);
                }
            }

        if (numeric)
        {
            if (LiqMl == downer.ml_500) counterML500();
            if (LiqMl == downer.ml_250) counterML250();
            if (LiqMl == downer.ml_100) counterML100();
        }
    }
}