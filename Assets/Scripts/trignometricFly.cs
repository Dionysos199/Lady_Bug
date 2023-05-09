// Imad El Khechen
//771989 
//Electronics Elective winter semester 2021/2022
//Prof. Gabler
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trignometricFly : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(checkFrequency());
    }
    public float Yamplitude;
    public float Zamplitude;
    public float Yangle;
    private float frequency;

    public float PhiX;
    public float PhiZ;
    // Update is called once per frame
    void Update()
    {
        if (ReadIMUSensor.readValues[3] > 1)
        {
            this.gameObject.SetActive (true);
          
        }
        else
        {

            //this.gameObject.SetActive(false);
            frequency = 0;
        }
        transform.localRotation= Quaternion.Euler(0,Yamplitude * Mathf.Sin(frequency * Time.time + PhiX), Zamplitude* Mathf.Sin(frequency * Time.time+PhiZ ));

     
     

    }
    IEnumerator checkFrequency()
    {
        for (;; )
        {

            yield return new WaitForSeconds(1.0f);
            frequency = ReadIMUSensor.readValues[3] * 10;
        }
    }
}
