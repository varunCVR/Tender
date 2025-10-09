using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSliderToItsPos : MonoBehaviour
{
    public GameObject target;
    public bool isWaterDrop;
    public bool plantSeedsIsOn;

    bool timeToMove;
    bool positionedCorrectly;
    bool execOnce;
    bool plantsGrewUp;
    public Color emmisionColor;
    public Color purple;
    public Texture[] textures;
    public Renderer renderer;
    public Renderer lcdDisplayRenderer;
    public Renderer glassOne;
    public Renderer glassTwo;


    private void Awake()
    {
        emmisionColor = new Color(0.2941177f, 0.2941177f, 0.2941177f, 0);
        purple = new Color(0.3529412f, 0.2862745f, 0.3529412f, 1f);
    }

    private void Update()
    {
        if (timeToMove)
        {
            transform.eulerAngles = new Vector3(0f, 92.5f, 0f);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime);
            if(Vector3.Distance(transform.position, target.transform.position) <= 0.005f)
            {
                positionedCorrectly = true;
            }
            else
            {
                positionedCorrectly = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("N"))
        {
            timeToMove = true;
            execOnce = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("N"))
        {
            if (positionedCorrectly && execOnce && isWaterDrop&&plantSeedsIsOn)
            {
                StartCoroutine(ChangeTextures());
                execOnce = false;
            }else if (!positionedCorrectly)
            {
                StopAllCoroutines();
                renderer.material.SetTexture("_BaseMap", null);
                renderer.material.SetColor("_EmissionColor", emmisionColor);

                glassOne.material.SetTexture("_BaseMap", null);
                glassOne.material.SetColor("_EmissionColor", emmisionColor);

                glassTwo.material.SetTexture("_BaseMap", null);
                glassTwo.material.SetColor("_EmissionColor", emmisionColor);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("N"))
        {
            timeToMove = false;
        }
    }
    IEnumerator ChangeTextures()
    {
        if (!plantsGrewUp)
        {
            lcdDisplayRenderer.materials[1].color = purple;
            renderer.material.color = purple;
            renderer.material.SetTexture("_BaseMap", textures[0]);
            renderer.material.SetColor("_EmissionColor", Color.black);

            glassTwo.material.SetTexture("_BaseMap", null);
            glassTwo.material.SetColor("_EmissionColor", emmisionColor);

            glassOne.material.SetTexture("_BaseMap", null);
            glassOne.material.SetColor("_EmissionColor", emmisionColor);
            yield return new WaitForSeconds(10f);
            renderer.material.SetTexture("_BaseMap", textures[1]);

            glassOne.material.SetTexture("_BaseMap", textures[1]);
            glassTwo.material.SetTexture("_BaseMap", textures[1]);

            yield return new WaitForSeconds(5f);
            renderer.material.SetTexture("_BaseMap", textures[2]);
            glassOne.material.SetTexture("_BaseMap", textures[2]);
            glassTwo.material.SetTexture("_BaseMap", textures[2]);

            yield return new WaitForSeconds(5f);
            renderer.material.SetTexture("_BaseMap", textures[3]);
            glassOne.material.SetTexture("_BaseMap", textures[3]);
            glassTwo.material.SetTexture("_BaseMap", textures[3]);

            yield return new WaitForSeconds(5f);
            renderer.material.SetTexture("_BaseMap", textures[4]);
            glassOne.material.SetTexture("_BaseMap", textures[4]);
            glassTwo.material.SetTexture("_BaseMap", textures[4]);

            yield return new WaitForSeconds(5f);
            renderer.material.SetTexture("_BaseMap", textures[5]);
            glassOne.material.SetTexture("_BaseMap", textures[5]);
            glassTwo.material.SetTexture("_BaseMap", textures[5]);

            yield return new WaitForSeconds(5f);
            renderer.material.SetTexture("_BaseMap", textures[6]);
            glassOne.material.SetTexture("_BaseMap", textures[6]);
            glassTwo.material.SetTexture("_BaseMap", textures[6]);
            plantsGrewUp = true;
        }
        else
        {
            renderer.material.SetTexture("_BaseMap", textures[6]);
            renderer.material.SetColor("_EmissionColor", Color.black);

            glassOne.material.SetTexture("_BaseMap", textures[6]);
            glassOne.material.SetColor("_EmissionColor", Color.black);
            glassTwo.material.SetTexture("_BaseMap", textures[6]);
            glassTwo.material.SetColor("_EmissionColor", Color.black);
        }


    }
}
