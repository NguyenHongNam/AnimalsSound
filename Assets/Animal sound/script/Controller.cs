using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float sensitivity = 100f;
    public float loudness = 0f;

    public UnityEngine.UI.Slider volumeSlider;
    public UnityEngine.UI.Image volumeImage;
    public float maxFillAmount = 1f;

    AudioSource _audio;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
        _audio.clip = Microphone.Start(null, true, 10, 44100);
        _audio.loop = true;

        while (!(Microphone.GetPosition(null) > 0))
        {

        }

        _audio.Play();
    }

    // Update is called once per frame
    void Update()
    {

        volumeSlider.value = loudness;
        volumeImage.fillAmount = loudness * maxFillAmount;

        //loudness = GetAverageVolume() * sensitivity;

        float targetLoudness = GetAverageVolume() * sensitivity;
        loudness = Mathf.Lerp(loudness, targetLoudness, Time.deltaTime * 2f);
    }

    float GetAverageVolume()
    {

        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data, 0);

        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }

        return (a / 256f);
    }
}


