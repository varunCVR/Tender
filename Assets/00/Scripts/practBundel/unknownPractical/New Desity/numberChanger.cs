using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberChanger : MonoBehaviour
{
    public Text readerUpdate;
    [Space]
    public enter_wtr firstLiq;
    public enter_wtr firstLiq1;
    public enter_wtr firstLiq_w;
    [Space] 
    public for_saltwtr slatLiq;
    public for_saltwtr slatLiq_s;
    
    [Space] 
    public saltExit slt;
    [Space] 
    public float i;
    
    
    private void Update()
    {
        if (!slt.slatyAll)
        {
            if (firstLiq.onoff || firstLiq1.onoff || firstLiq_w.onoff) 
            {
                if (i > 260) { 
                    i-=Time.deltaTime*25f;
                }
            } 
            
            if (slatLiq.onoff)
            {
                if (i > 240) { 
                    i-=Time.deltaTime*25f;
                }
            }
            
            if (!firstLiq.onoff && !firstLiq1.onoff && !firstLiq_w.onoff && !slatLiq_s.onoff )
            {
                if (i < 300)
                { 
                    i+=Time.deltaTime*25f;
                }
            }
        }

        if (slt.slatyAll)
        {
            if (firstLiq.onoff || firstLiq1.onoff)
            {
                if (i > 260)
                {
                    i -= Time.deltaTime * 25f;
                }
            }

            if (slatLiq.onoff || slatLiq_s.onoff)
            {
                if (i > 240)
                {
                    i -= Time.deltaTime * 25f;
                }
            }

            if (!firstLiq.onoff && !firstLiq1.onoff && !slatLiq_s.onoff && !slatLiq.onoff)
            {
                if (i < 300)
                {
                    i += Time.deltaTime * 25f;
                }
            }
        }

        i = Mathf.Clamp(i, 240, 300);

        readerUpdate.text = ""+i.ToString("000");

    }
}
