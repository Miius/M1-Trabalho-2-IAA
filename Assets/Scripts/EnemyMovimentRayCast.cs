using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovimentRayCast : MonoBehaviour
{
    bool far = true;
    int speed = 25;
    int turnForce = 90;
    float l, r;

    void Update()
    {
        /*if (Input.GetKey(KeyCode.LeftArrow))
            Turn(turnForce * -1);
        if (Input.GetKey(KeyCode.RightArrow))
            Turn(turnForce);*/
        Raycast();
        
        Move();
    }

    void Raycast()
    {
        RaycastHit forward;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out forward, Mathf.Infinity))
        {
            float d = Vector3.Distance(transform.position, forward.point);
            
            if (d >= 15)
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * forward.distance, Color.white);
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * forward.distance, Color.red);

                transform.position += transform.forward * Time.deltaTime * speed * 2*-1;
            }
        }


        RaycastHit left;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left + Vector3.forward), out left, Mathf.Infinity))
        {
            l = Vector3.Distance(transform.position, left.point);
           
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left + Vector3.forward) * left.distance, Color.red);
            
            if (l > r)
                Turn(turnForce * -1);
        }


        RaycastHit right;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right + Vector3.forward), out right, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right + Vector3.forward) * right.distance, Color.blue);
            
            r = Vector3.Distance(transform.position, right.point);
            
            if (r > l)
                Turn(turnForce);
        }
        
        
    }

    public void Move()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    public void Turn(int value)
    {
        transform.rotation *= Quaternion.Euler(0, value * Time.deltaTime, 0);
    }

}
