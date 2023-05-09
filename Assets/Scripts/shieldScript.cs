// Imad El Khechen
//771989 
//Electronics Elective winter semester 2021/2022
//Prof. Gabler
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour
{
    public Vector3 maxRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ReadIMUSensor.readValues[3] > 1)
        {
            open();
        }
        else
        {
            close();
        }
        
    }
    void close()
    {
        transform.localRotation = Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(Vector3.zero), .1f);

    }
    void open()
    {
        transform.localRotation = Quaternion.Lerp(Quaternion.Euler(Vector3.zero), Quaternion.Euler(maxRotation),.5f);

    }
}
