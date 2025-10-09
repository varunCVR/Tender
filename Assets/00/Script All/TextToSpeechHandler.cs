using System;
using Meta.WitAi.TTS.Utilities;
using UnityEngine;

public class TextToSpeechHandler : MonoBehaviour
{
    public TTSSpeaker ttsSpeaker;

    public float delay;
    public string message;

    public bool speak;
    private void Start()
    {
        //ttsSpeaker.Speak("Hi This is text to pseech demo");
    }

    void Update()
    {
        if (speak)
        {
            ttsSpeaker.Speak(message);
            speak = false;
        }
    }
}
