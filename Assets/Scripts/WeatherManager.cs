using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using System.Text;

public class WeatherManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }
    public float cloudValue { get; private set; }
    // 
    private NetworkService _network;

    public void Startup(NetworkService service)
    {
        Debug.Log("Wheather manager startup...");

        _network = service;
        StartCoroutine(_network.GetWeatherXML(OnXMLDataLoaded));
        status = ManagerStatus.Initializing;
    }

    public void OnXMLDataLoaded(string data)
    {
        Debug.Log(data);
        string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
        if (data.StartsWith(_byteOrderMarkUtf8))
        {
            Debug.Log("Yes1");
            data = data.Remove(0, _byteOrderMarkUtf8.Length);

        }

        XmlDocument doc = new XmlDocument(); // create class example

        Debug.Log(data);

        doc.LoadXml(data); // pars a xml code


       // XmlNode root = doc.DocumentElement;


        //doc.LoadXml(data);



        // XmlNode root = doc.DocumentElement;

        // XmlNode node = root.SelectSingleNode("clouds");
        //string value = node.Attributes["value"].Value;
        //cloudValue = Convert.ToInt32(value) / 100f;

        //Debug.Log("Value: "+cloudValue);

        MessengerInternal.DEFAULT_MODE = MessengerMode.DONT_REQUIRE_LISTENER;
        Messenger.Broadcast(GameEvent.WEATHER_UPDATED);
        status = ManagerStatus.Started;
    }
}


