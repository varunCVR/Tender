using UnityEngine;

public class pipet10MLliq : MonoBehaviour
{
    public Renderer pipetRend;

    public bool startMethod;
    public bool updateMethod;

    [Range(-1.2f, 10)]
    public float fillp;

    private void Start()
    {
        if (startMethod) counterML100();
    }

    private void Update()
    {
        if (updateMethod) counterML100();
    }

    private void counterML100()
    {
        if (fillp <= -1.2f && pipetRend.enabled)
        {
            pipetRend.enabled = false;
        }

        if (fillp > -1.2f && !pipetRend.enabled)
        {
            pipetRend.enabled = true;
        }
        
        var filler = (0.0088f*2);
        var realFill = fillp * filler;
        pipetRend.material.SetFloat("_Fill", realFill);
    }
}   

// -0.011