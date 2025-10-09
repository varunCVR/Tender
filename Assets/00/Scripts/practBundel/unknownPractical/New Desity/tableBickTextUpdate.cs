using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tableBickTextUpdate : MonoBehaviour
{
    public updateDensityText textDetails;

    public TextMeshProUGUI e_bicker;
    public TextMeshProUGUI e_bicker_Water;

    public TextMeshProUGUI w_bicker;
    public TextMeshProUGUI w_bicker_Water;
    
    public TextMeshProUGUI s_bicker;
    public TextMeshProUGUI s_bicker_Water;
    void Update()
    {
        if (textDetails.eWbicker)
        {
            e_bicker.text = "165";
            e_bicker_Water.text = "000";
        }

        if (textDetails.nWbicker)
        {
            w_bicker.text = "205";
            w_bicker_Water.text = "040";
        }

        if (textDetails.sWbicker)
        {
            s_bicker.text = "225";
            s_bicker_Water.text = "060";
        }
    }
}
