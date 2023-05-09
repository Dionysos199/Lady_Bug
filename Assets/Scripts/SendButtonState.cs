using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class SendButtonState : MonoBehaviour
{
    public GameObject indicator;
    private const int outputPin = 7;
    private bool oldState = false; 

    void Start()
    {
        UduinoManager.Instance.pinMode(outputPin, PinMode.Output);
        Debug.Log(PinMode.Output);
    }

    // Update is called once per frame
    void Update()
    {
        // send cdommand only if there was a state change
        if (indicator.activeSelf != oldState)
        {
            Debug.Log(indicator.activeSelf);

            // send a boolen value by command to switch digital output on/off
            if (indicator.activeSelf)
            {
                UduinoManager.Instance.sendCommand("BP", 1);
            }
            else {
                UduinoManager.Instance.sendCommand("BP", 0);
            }
            oldState = indicator.activeSelf;
        }

        /* ?? geht nicht mehr...
        // or toggle value of output pin directly:
        if (!indicator.activeSelf)
        {
            UduinoManager.Instance.digitalWrite(outputPin, State.HIGH);
        }
        else
        {
            UduinoManager.Instance.digitalWrite(outputPin, State.LOW);
        }
        */

    }
}
