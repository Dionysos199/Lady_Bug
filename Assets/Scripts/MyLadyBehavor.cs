// Imad El Khechen
//771989 
//Electronics Elective winter semester 2021/2022
//Prof. Gabler
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLadyBehavor : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update

    float maxHeight = 90;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Debug.Log("xrotation"+ReadIMUSensor.readValues[0]);
        Debug.Log("yrotation" + ReadIMUSensor.readValues[1]);
        Debug.Log("zrotation" + ReadIMUSensor.readValues[2]);

        //transform.rotation = Quaternion.Lerp(Quaternion.identity, 
        // Quaternion.Euler( ReadIMUSensor.readValues[0], -1*ReadIMUSensor.readValues[2], ReadIMUSensor.readValues[1]),.2f);

        transform.rotation = Quaternion.Euler(ReadIMUSensor.readValues[0], -1 * ReadIMUSensor.readValues[2], ReadIMUSensor.readValues[1]);
        float liftForce = ReadIMUSensor.readValues[3];
        rb.AddForce(transform.up*liftForce);
     

        //constrain the beetle to the terrain limits and prevents falling through the ground

        if (transform.position.y > maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        }
        if (transform.position.y <0)
        {
            Vector3 pos = transform.position;
            pos.y = Terrain.activeTerrain.SampleHeight(transform.position)+.3f;
            transform.position = pos;
        }
        if (transform.position.x > 1000)
        {
            transform.position = new Vector3(1000, transform.position.y, transform.position.z);
        }
        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0,transform.position.y, transform.position.z);
        }     
        if (transform.position.z > 1000)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 1000);
        }
        if (transform.position.z <0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,0);
        }


    }
    // Update is called once per frame
}
