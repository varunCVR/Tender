using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ChangeSkybox : MonoBehaviour
{
    public Material skyMat,videoMat;

    public GameObject[] allOtherObjectsInScene;

    public GameObject playButton,stopButton;
    public VideoPlayer player;
    VideoClip clip;

    public GameObject resetExitButtons;

    public GameObject bottomPlane;
    public AudioForDemo2 audio;

    private void Start()
    {
        playButton.SetActive(true);
        stopButton.SetActive(false);
        clip = player.clip;
        bottomPlane.SetActive(false);
    }

    public void ChangeSkyboxToVideo()
    {
        audio.PlayAudioInSequence();
        bottomPlane.GetComponent<MeshRenderer>().enabled = false;
        bottomPlane.SetActive(true);
        for(int i = 0; i< allOtherObjectsInScene.Length; i++)
        {
            allOtherObjectsInScene[i].SetActive(false);
            
        }
        player.Play();
        resetExitButtons.SetActive(false);
        RenderSettings.skybox = videoMat;
        playButton.SetActive(false);
        stopButton.SetActive(true);
        StartCoroutine(GetVideoLenght());
    }
    public void ChangeSkyboxToOriginal()
    {
        for (int i = 0; i < allOtherObjectsInScene.Length; i++)
        {
            allOtherObjectsInScene[i].SetActive(true);

        }
        audio.StopAudios();
        resetExitButtons.SetActive(true);
        bottomPlane.SetActive(false);
        player.Stop();
        RenderSettings.skybox = skyMat;
        playButton.SetActive(true);
        stopButton.SetActive(false);
    }

    IEnumerator GetVideoLenght()
    {
        yield return new WaitForSeconds((float)clip.length);
        ChangeSkyboxToOriginal();
        yield return new WaitForSeconds(0.05f);

    }
}
