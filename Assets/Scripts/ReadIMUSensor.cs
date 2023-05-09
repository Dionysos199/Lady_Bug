// Imad El Khechen
//771989 
//Electronics Elective winter semester 2021/2022
//Prof. Gabler
using UnityEngine;
using System.Collections;
using System.Globalization;
using Uduino;
using System;

public class ReadIMUSensor : MonoBehaviour
{
    UduinoDevice myDevice;

    public static event Action<float> dataRecieved;
    enum values { xRotation, yRotation, zRotation, flowSensor
        }
    public static float[] readValues = new float[] { 0, 0, 0, 0,0 };

    void Awake()
    {
        UduinoManager.Instance.OnDataReceived += OnDataReceived; //Create the Delegate
    }

    private void Start()
    {
        myDevice = UduinoManager.Instance.GetBoard("ImadsUno");
    }

    void FixedUpdate() {

        // Read every frame the value of the "mySensor" function on our board. 
        UduinoManager.Instance.Read(myDevice, "imuSensor");
       // UduinoManager.Instance.Read(myDevice, "flowSensor");


    }

    public void OnDataReceived(string data, UduinoDevice device)
    {
        //Debug.Log(data); // Use the data as you want !
        // now it's necessary to parse the string for ',' to sperate the values
        Debug.Log("data"+ data);
        string[] vecOrientation = data.Split(',');
        Debug.Log("length"+vecOrientation.Length);
        if (vecOrientation.Length >= 4)
        {
            float r= readValues[0] = float.Parse(vecOrientation[0], CultureInfo.InvariantCulture);
            float p=  readValues[1] = float.Parse(vecOrientation[1], CultureInfo.InvariantCulture);
            float h=  readValues[2] = float.Parse(vecOrientation[2], CultureInfo.InvariantCulture);
            // reading analog value as altitude
           float flow= readValues[3] = float.Parse(vecOrientation[3], CultureInfo.InvariantCulture);


            float flexValue = readValues[4] = float.Parse(vecOrientation[4], CultureInfo.InvariantCulture);

            Debug.Log("Vec:" + r + ',' + p + ',' + h + ',' + flow +','+flexValue);


            //MyLadyBehavor myLadyBehavor = MyLady.GetComponent<MyLadyBehavor>();
            //myLadyBehavor._rotation = Quaternion.Euler(r, h * -1.0f, p);
            //myLadyBehavor.flappSpeed= 2-(Dampen(flowSensorRead)/500);

            //ParticleSystem weather = weatherObject.GetComponent<ParticleSystem>();
            //var em = weather.emission;
            //em.rateOverTime = r;
        }
        else {

            Debug.Log("Wrong data format");

        }
    }
   
    
    float Dampen(float nb)
    {
       return Mathf.Ceil(nb / 10)*10;
    }
}
