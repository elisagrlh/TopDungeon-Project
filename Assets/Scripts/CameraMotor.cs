using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private void LateUpdate() 
    {
        Vector3 delta = Vector3.zero;

        float deltaX = lookAt.position.x - transform.position.x; //transform.position.x is the center of the camera, here we're trying to get the distance between the center of the camera and the player
        if (deltaX > boundX || deltaX < -boundX )
        {
            if (transform.position.x < lookAt.position.x) //it means that the player is on the right and the focus of the camera on the left
                delta.x = deltaX - boundX;
            else
                delta.x = deltaX + boundX;
        }



        float deltaY = lookAt.position.y - transform.position.y; //transform.position.x is the center of the camera, here we're trying to get the distance between the center of the camera and the player
        if (deltaY > boundY || deltaY < -boundY )
        {
            if (transform.position.y < lookAt.position.y) 
                delta.y = deltaY - boundY;
            else
                delta.y = deltaY + boundY;
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
