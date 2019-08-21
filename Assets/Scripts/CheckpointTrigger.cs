using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public string identify;

    private bool _triggered;

    void OnTriggerEnter(Collider other)
    {
        if (_triggered)
        {
            return;
        }

        Managers.Weather.LogWheather(identify);
        _triggered = true;
    }
}
