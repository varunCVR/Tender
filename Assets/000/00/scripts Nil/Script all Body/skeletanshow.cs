using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletanshow : MonoBehaviour
{
    public GameObject Skin, Muscular, Skeletan, Circulatory, Nervous, Respitatory, Digestive, Urinary;

    public void hide()
    {
        
        Skin.SetActive(false);
        Muscular.SetActive(false);
        Skeletan.SetActive(true);
        Circulatory.SetActive(false);
        Nervous.SetActive(false);
        Respitatory.SetActive(false);
        Digestive.SetActive(false);
        Urinary.SetActive(false);
              
    }

}
