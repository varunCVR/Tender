using BNG;
using UnityEngine;
using UnityEngine.UI;

public class ShootLaserSecForAndroid : MonoBehaviour
{
    public Material material;
    private LaserBeam beam;

    public bool isOn;

    /*public Grabber rightGrabber;
    public Grabber leftGrabber;*/  //Old Code

    public Text refractionTextOne;
    public Text refractionTextTwo;
    public Text reflectionText;

    public Text refractionTextOneOnCnavas,refractionTextTwoOnCnavas,reflectionTextOnCanvas;


    public void Grabbed()
    {
        isOn = true;
    }

    public void Released()
    {
        isOn = false;
    }

    private void Update()
    {
      
        if (isOn)
        {
            if (beam != null)
                Destroy(beam.laserObj);
            beam = new LaserBeam(gameObject.transform.position, gameObject.transform.right, material);
            
            reflectionTextOnCanvas.text = beam.reflectionVector.ToString("00") + "\u00B0";
            refractionTextOneOnCnavas.text = beam.refrectedVectorOne.ToString("00") + "\u00B0";
            refractionTextTwoOnCnavas.text = beam.refractedVector2.ToString("00") + "\u00B0";
            
            refractionTextOne.transform.position = new Vector3(beam.RayPos.x, beam.RayPos.y, beam.RayPos.z);
            refractionTextTwo.transform.position = new Vector3(beam.RayPos2.x, beam.RayPos2.y, beam.RayPos2.z);
            reflectionText.transform.position = new Vector3(beam.RayPos3.x, beam.RayPos3.y, beam.RayPos3.z - .2f);
            reflectionText.text = beam.reflectionVector.ToString("00") + "\u00B0";
            refractionTextOne.text = beam.refrectedVectorOne.ToString("00") + "\u00B0";
            refractionTextTwo.text = beam.refractedVector2.ToString("00") + "\u00B0";
            
          
        }
        else
        {
            if (beam != null)
                Destroy(beam.laserObj);
        }
    }
}