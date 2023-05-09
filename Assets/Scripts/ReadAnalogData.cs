// Imad El Khechen
//771989 
//Electronics Elective winter semester 2021/2022
//Prof. Gabler
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using UnityEngine.Events;
using System;


public class ReadAnalogData : MonoBehaviour
{
    UduinoDevice myDevice;
   
    public float floatdata { get; set; }
    public static event Action<float> dataRecieved;

    private void Awake()
    {
        UduinoManager.Instance.OnDataReceived += OnDataReceived;
        
    }
    // Start is called before the first frame update
    void Start()
    {

        myDevice = UduinoManager.Instance.GetBoard("ImadsUno"); 
    }

    // Update is called once per frame
    void Update()
    {
        UduinoManager.Instance.Read(myDevice, "mySensor");

        //UduinoManager.Instance.Read(myDevcie, "imuSensor");
    }

    public void OnDataReceived(string data, UduinoDevice device)
    {
     

       
            Debug.Log("dataData" + data);

            floatdata = Mathf.Ceil(float.Parse(data));
            dataRecieved?.Invoke(floatdata);
        
    }
}
