using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider; //is private bc only need to call it on a start or awake function
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>(); //requires a boxcollider2d on any objects that this scripts is on
    }

    protected virtual void Update()
    {
        //Collision work
        boxCollider.OverlapCollider(filter, hits);

        for (int i=0; i<hits.Length; i++)
        {
            if(hits[i] == null)
                continue;

            else
                Debug.Log(hits[i].name);

            //The array is not cleaned up, so we do it ourself
            hits[i] = null;
        }
    }
}
