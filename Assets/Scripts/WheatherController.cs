using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatherController : MonoBehaviour
{
    [SerializeField] private Material sky;
    [SerializeField] private Light sun;

    private float _fullIntensity;

    void Awake()
    {
        Messenger.AddListener(GameEvent.WEATHER_UPDATED, OnWeatherUpdate);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.WEATHER_UPDATED, OnWeatherUpdate);
    }

    void Start()
    {
        _fullIntensity = sun.intensity;

    }


    private void OnWeatherUpdate()
    {
        SetOvercast(Managers.Weather.cloudValue);
    }


    private void SetOvercast(float value)
    {
        //if (value <= 1)
        //{
            sky.SetFloat("_Blend", value);
            sun.intensity = _fullIntensity - (_fullIntensity * value);
       // }

    }
}
