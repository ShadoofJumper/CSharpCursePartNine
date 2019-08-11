using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatherController : MonoBehaviour
{
    [SerializeField] private Material sky;
    [SerializeField] private Light sun;

    private float _fullIntensity;
    private float _cloudeValue = 0f;

    void Start()
    {
        _fullIntensity = sun.intensity;

    }


    void Update()
    {
        SetOvercast(_cloudeValue);
        _cloudeValue += .005f;
    }

    private void SetOvercast(float value)
    {
        if (value <= 1)
        {
            sky.SetFloat("_Blend", value);
            sun.intensity = _fullIntensity - (_fullIntensity * value);
        }

    }
}
