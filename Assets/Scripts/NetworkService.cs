using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NetworkService
{
    // weather api http://openweathermap.org/api
    private const string xmlApi = "api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=0a8994dca3365d66ad0b10ee0baafc7e";
        //"http://api.openweathermap.org/data/2.5/weather?q=Chicago,us&mode=xml";

    private bool IsResponseValid(WWW www)
    {
        Debug.Log(www.text);
        Debug.Log(www.error);
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
        yield return www; // pause in download procces

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

}
