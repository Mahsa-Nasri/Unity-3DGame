using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* this script is attached to main camera to follow the character.*/
public class cameraFollow : MonoBehaviour
{
   public Transform target;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        Vector3 newpos = target.position + offset;
        newpos.y = offset.y;
        transform.position = newpos;


    }
}
