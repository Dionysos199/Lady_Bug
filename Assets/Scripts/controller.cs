using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    public float rotationSpeed;

    float xrotation = 0;
    float zrotation = 0;

    float yrotation = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
       
       //transform.rotation = Quaternion.Euler(90 * Mathf.Sin(Time.time), 0, 0);
        if (Input.GetAxis("Vertical")==1)
        {
            rb.AddForce(transform.up);
        }
        if (Input.GetAxis("Horizontal") == 1)
        {
            yrotation += .1f;
        }
        if (Input.GetAxis("Horizontal") == -1)
        {
            yrotation -= .1f;
        }

        if (Input.GetAxis("Mouse X")>0)
        {
            if(transform.rotation.x<45)
            xrotation+=rotationSpeed;
        }
        if (Input.GetAxis("Mouse X")<0)
        {
            if(transform.rotation.x>-45)
            xrotation-=rotationSpeed;
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            if (transform.rotation.x < 45)
                zrotation += rotationSpeed;
        }
        if (Input.GetAxis("Mouse Y") < 0)
        {
            if (transform.rotation.x > -45)
                zrotation -= rotationSpeed;
        }
        transform.rotation = Quaternion.Euler(xrotation, yrotation, zrotation);
    }
}
