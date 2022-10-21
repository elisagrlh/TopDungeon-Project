using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal"); //GetAxisRaw returns 0, 1 or -1 : 0 for nothing, -1 for left, and 1 for right
        float y = Input.GetAxisRaw("Vertical");

        //Reset MoveDelta
        moveDelta = new Vector3(x,y,0); //because it's 2D
        
        //Debug.Log(x);
        //Debug.Log(y);

        //Swap sprite direction, whether you're going right or left
        if(moveDelta.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        
        else if(moveDelta.x < 0) //use of else if bc if moveDelta=0 then the else would be doing nothing
            transform.localScale = new Vector3(-1, 1, 1);

    
        //make the player move
        transform.Translate(moveDelta * Time.deltaTime);

    }
}
