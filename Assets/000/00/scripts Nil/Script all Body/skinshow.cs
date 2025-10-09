using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinshow : MonoBehaviour
{
    public GameObject Skin, Muscular, Skeletan, Circulatory, Nervous, Respitatory, Digestive, Urinary;

    public void hide()
    {
        
        Skin.SetActive(true);
        Muscular.SetActive(false);
        Skeletan.SetActive(false);
        Circulatory.SetActive(false);
        Nervous.SetActive(false);
        Respitatory.SetActive(false);
        Digestive.SetActive(false);
        Urinary.SetActive(false);
              
    }

}
