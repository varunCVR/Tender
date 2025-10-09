using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nervousshow : MonoBehaviour
{
    public GameObject Skin, Muscular, Skeletan, Circulatory, Nervous, Respitatory, Digestive, Urinary;

    public void hide()
    {
        
        Skin.SetActive(false);
        Muscular.SetActive(false);
        Skeletan.SetActive(false);
        Circulatory.SetActive(false);
        Nervous.SetActive(true);
        Respitatory.SetActive(false);
        Digestive.SetActive(false);
        Urinary.SetActive(false);
              
    }

}
