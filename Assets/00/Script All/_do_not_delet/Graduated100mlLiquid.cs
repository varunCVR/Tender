using UnityEngine;

public class Graduated100mlLiquid : MonoBehaviour
{
    public Transform graduatedLiquid;


    [Range(10, 100)] public float fillML;


    private void Update()
    {
        counterML100();
    }

    private void counterML100()
    {
        var filler = 0.0111111111111111f;
        var realFill = (fillML - 10) * filler;
        if (realFill > 0) graduatedLiquid.localScale = new Vector3(1, realFill, 1);
        if (realFill < 0) graduatedLiquid.localScale = new Vector3(1, 0, 1);
    }
}