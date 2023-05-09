// Imad El Khechen
//771989 
//Electronics Elective winter semester 2021/2022
//Prof. Gabler
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wingBehavior : MonoBehaviour
{
    public float flapSpeed{ get; set; }
    public bool left;
    public float flapAngle=90;
    MeshRenderer _meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
 
     void flappWing( float _flappSpeed)
    {
        if (_flappSpeed > .5)
        {
            _meshRenderer.enabled = true;
            float speed=40;

            if (left)
            {

                transform.rotation = Quaternion.Euler(flapAngle * Mathf.Sin(speed*flapSpeed * Time.time), 0, 0);
            }
            else
            {

                transform.rotation = Quaternion.Euler(flapAngle * Mathf.Sin(speed*flapSpeed * Time.time + Mathf.PI), 180, 0);
            }
        }
        else if (_flappSpeed < .5)
        {
            _meshRenderer.enabled = false;
        }
    }
        // Update is called once per frame
        void Update()
    {
        flappWing(flapSpeed);
    }
}
