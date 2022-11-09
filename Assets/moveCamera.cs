using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCamera : MonoBehaviour
{
    private float speedH = 2;
    private float speedV = 2;
    public static float yaw = 0;
    public static float pitch = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0);
        transform.position = new Vector3(movePlayer.x, movePlayer.y, movePlayer.z);
    }
}
