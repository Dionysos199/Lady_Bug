using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPlaneColor : MonoBehaviour
{
    private Color planeColor;
    public float xposition { get ; set; }
    public GameObject DataObject;
    private float flapAngle=90;
    public bool left;
    void Start()
    {
    
    }
    private void Update()
    {
        ReadAnalogData readAnalogData = DataObject.GetComponent<ReadAnalogData>();
        float datafloat = readAnalogData.floatdata;
        Debug.Log(datafloat);
        // transform.position = new Vector3 (xposition,0,0);

        //Get the Renderer component from the new cube

        //Call SetColor using the shader property name "_Color" and setting the color to red
        setColor(datafloat);
        fly(datafloat);
    }



    void setColor(float datafloat)
    {      
        Color color = new Color(1 - datafloat / 100, datafloat / 100, 0);
       // var Renderer = GetComponentInChildren<Renderer>();
      //  Renderer.material.SetColor("_Color", color);
    }

    void fly(float flapSpeed)
    {
        if (left)
        {
            transform.rotation = Quaternion.Euler(flapAngle * Mathf.Sin(flapSpeed * Time.time), 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(flapAngle * Mathf.Sin(flapSpeed * Time.time+Mathf.PI), 0, 0);
        }
    }
}
