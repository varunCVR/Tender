using System.Collections;
using UnityEngine;

public class AudioDemo13 : MonoBehaviour
{
    public AudioClip one,two,three,four,five;
    public AudioSource audioSource;

    private void Start()
    {
        StartCoroutine(PlayAudio());
    }

    IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(1.5f);

        audioSource.PlayOneShot(one);
        yield return new WaitForSeconds(one.length + 0.5f);

        audioSource.PlayOneShot(two);
        yield return new WaitForSeconds(two.length + 0.5f);

        audioSource.PlayOneShot(three);
        yield return new WaitForSeconds(three.length + 0.5f);

        audioSource.PlayOneShot(four);
        yield return new WaitForSeconds(four.length + 0.5f);

        audioSource.PlayOneShot(five);
        yield return new WaitForSeconds(five.length + 0.5f);
    }
}
