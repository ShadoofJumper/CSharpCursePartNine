using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NetworkService
{
    // weather api http://openweathermap.org/api
    private const string xmlApi = "api.openweathermap.org/data/2.5/weather?q=Chicago,us&APPID=0a8994dca3365d66ad0b10ee0baafc7e&mode=xml";
    private const string jsonApi = "api.openweathermap.org/data/2.5/weather?q=Chicago,us&APPID=0a8994dca3365d66ad0b10ee0baafc7e";
    private const string webImage = "https://mobalytics.gg/wp-content/uploads/2018/09/Varus_ConquerorSkin.jpg";


    private bool IsResponseValid(WWW www)
    {
        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Bad connect");
            return false;
        }
        else if (string.IsNullOrEmpty(www.text))
        {
            Debug.Log("Bad data");
            return false;
        }
        else
        {
            return true;
        }
    }

    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        WWW www = new WWW(url);  //send http cal by creating a new web object
        yield return www; // pause while download procces

        if (!IsResponseValid(www))
        {
            yield break; // stop a so-program if have error
        }

        callback(www.text);
    }

    public IEnumerator GetWeatherXML(Action<string> callback)
    {
        return CallAPI(xmlApi, callback);
    }

    public IEnumerator GetWeatherJSON(Action<string> callback)
    {
        return CallAPI(jsonApi, callback);
    }

    public IEnumerator DownloadImage(Action<Texture2D> callback)
    {
        WWW www = new WWW(webImage);
        yield return www;
        callback(www.texture);
    }
}
