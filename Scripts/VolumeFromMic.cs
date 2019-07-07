using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeFromMic : MonoBehaviour
{

    public static VolumeFromMic Inctance { set; get; }

    public static float MicLoudness;

    //この下のstatic floatにdb値が入っている
    public static float MicLoudnessinDecibels;

    private string _device;

    public void InitMic()
    {
        if (_device == null)
        {
            _device = Microphone.devices[0];
        }
        _clipRecord = Microphone.Start(_device, true, 999, 44100);
        _isInitialized = true;
    }

    public void StopMicrophone()
    {
        Microphone.End(_device);
        _isInitialized = false;
    }


    AudioClip _clipRecord;
    AudioClip _recordedClip;
    int _sampleWindow = 128;

    float MicrophoneLevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1);
        if (micPosition < 0) return 0;
        _clipRecord.GetData(waveData, micPosition);
        for (int i = 0; i < _sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }

    float MicrophoneLevelMaxDecibels()
    {

        float db = 20 * Mathf.Log10(Mathf.Abs(MicLoudness));
        return db;
    }

    public float FloatLinearOfClip(AudioClip clip)
    {
        StopMicrophone();

        _recordedClip = clip;

        float levelMax = 0;
        float[] waveData = new float[_recordedClip.samples];

        _recordedClip.GetData(waveData, 0);
        for (int i = 0; i < _recordedClip.samples; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }

    public float DecibelsOfClip(AudioClip clip)
    {
        StopMicrophone();

        _recordedClip = clip;

        float levelMax = 0;
        float[] waveData = new float[_recordedClip.samples];

        _recordedClip.GetData(waveData, 0);
        for (int i = 0; i < _recordedClip.samples; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }

        float db = 20 * Mathf.Log10(Mathf.Abs(levelMax));
        return db;
    }



    void Update()
    {
        MicLoudness = MicrophoneLevelMax();
        MicLoudnessinDecibels = MicrophoneLevelMaxDecibels();
        Debug.Log(MicLoudnessinDecibels);

    }

    bool _isInitialized;
    void OnEnable()
    {
        InitMic();
        _isInitialized = true;
        Inctance = this;
    }

    void OnDisable()
    {
        StopMicrophone();
    }

    void OnDestroy()
    {
        StopMicrophone();
    }


    void OnApplicationFocus(bool focus)
    {
        if (focus)
        {

            if (!_isInitialized)
            {
                InitMic();
            }
        }
        if (!focus)
        {
            StopMicrophone();
        }
    }
}