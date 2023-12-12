using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ : MonoBehaviour
{
    private float speed = 0.1f;

    private void Update()
    {
        float z = Input.GetAxisRaw("Vertical") * speed;
        float x = Input.GetAxisRaw("Horizontal") * speed;
        //transform.position = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        transform.Translate(x, 0, z);
    }
}
