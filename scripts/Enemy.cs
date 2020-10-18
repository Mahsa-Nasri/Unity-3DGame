using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script attached to enemy component. defines the movement of enemies.
public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector3 offsetPosEnd;
    private Vector3 startPos;
    private Vector3 targetPos;

    void Awake()
    {
        startPos = transform.position;
        targetPos = startPos + offsetPosEnd;


    }
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed* Time.deltaTime);

        if (transform.position == targetPos)
        {
            if (targetPos == startPos)
                targetPos = startPos + offsetPosEnd;
            else if(targetPos== startPos+ offsetPosEnd)
                targetPos = startPos;

           
        }
    }
}
