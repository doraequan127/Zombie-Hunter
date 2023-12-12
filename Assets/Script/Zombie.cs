using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private float speed;
    private GameObject Camera_default;
    private GameObject Camera_defaultFront;

    private void Awake()
    {
        Camera_default = GameObject.Find("Camera_default");
        Camera_defaultFront = GameObject.Find("Camera_defaultFront");
        speed = Random.Range(0.003f, 0.007f);
    }

    private void Update()
    {
        transform.LookAt(Camera_default.transform.position);
        //transform.Translate(Vector3.forward * speed);           //Cách 1
		//transform.position = Vector3.MoveTowards(transform.position, Camera_defaultFront.transform.position, speed);    //Cách 2
        transform.position = Vector3.Lerp(transform.position, Camera_defaultFront.transform.position, speed);    //Cách 3
    }
}
