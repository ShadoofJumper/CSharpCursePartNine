using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImageManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    private NetworkService _network;

    private Texture2D _webImage;

    public void Startup(NetworkService service)
    {
        Debug.Log("Image manager startup...");
        _network = service;

        status = ManagerStatus.Started;
    }

    public void GetWebImage(Action<Texture2D> callback)
    {
        if (_webImage == null)
        {
            StartCoroutine(_network.DownloadImage(callback));
        }
        else
        {
            callback(_webImage);
        }
    }

}
