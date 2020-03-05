using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    public float camWidth; // defining camera width attribute
    public float camHeight;// defining camera height attribute

    public float radius = 1f; // initiating and defining radius attribute

    // defning attributes for this script
    public bool keepOnScreen = true; 
    public bool isOnScreen = true;
    public bool offRight, offLeft, offUp, offDown; 

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize; // adjusting the camera when the game starts
        camWidth = camHeight * Camera.main.aspect;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position; 

        isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;

        if (pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
            isOnScreen = false;
            offRight = true;  // when enemy goes off the screen from right
        }
        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            isOnScreen = false;
            offLeft = true;// when enemy goes off the screen from left
        }
        if (pos.y > camWidth - radius)
        {
            pos.y = camWidth - radius;
            isOnScreen = false;
            offUp = true;// when enemy goes off the screen from up
        }
        if (pos.y < -camWidth + radius)
        {
            pos.y = -camWidth + radius;
            isOnScreen = false;
            offDown = true;// when enemy goes off the screen from down
        }

        isOnScreen = !(offRight || offLeft || offUp || offDown); // when enemies goes off the screen from sides or down then change the value to false
        if (keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }

        transform.position = pos;

    }


    //Drawing bounds in the scene
    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
