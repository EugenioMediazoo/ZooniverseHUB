using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAR : MonoBehaviour
{
    //time
    [Range(-100f, 100f)]
    public float speed;


    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
