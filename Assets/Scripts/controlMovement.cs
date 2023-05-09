using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float xpos;
    float ypos;

    // Update is called once per frame
    void Update()
    {
        xpos = Input.GetAxis("Horizontal");
        ypos = Input.GetAxis("Vertical");
        Ray ray = new Ray(transform.position,-transform.up);
        RaycastHit hitInfo;
        
        Physics.Raycast(ray, out hitInfo, 100);
        transform.position = hitInfo.point + hitInfo.normal / 10;
        Debug.Log("hitInfo" + hitInfo.point);
        transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        transform.position = transform.position + new Vector3(xpos, 0, ypos)/10 ;
    }
}
