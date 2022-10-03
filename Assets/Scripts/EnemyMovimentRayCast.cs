using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovimentRayCast : MonoBehaviour
{
    bool far = true;
    
    float speed = 25;
    float l, r,d;
    
    int turnForce = 180;
    int random;
    
    void Update()
    {
        Raycast();             
    }

    public void Raycast()
    {
        RaycastHit forward;       
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out forward, Mathf.Infinity))
        {
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * forward.distance, Color.white);
            d = Vector3.Distance(transform.position, forward.point);

            Move(speed);
            if(d < 15 && far)
            {
                far = false;
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * forward.distance, Color.red);              
                random = Random.Range(0, 2);
            }
            if(!far)
            {
                speed = -10;
                switch (random)
                {
                    case 0:
                        transform.rotation *= Quaternion.Euler(0, 360 * Time.deltaTime, 0);
                        break;
                    case 1:
                        transform.rotation *= Quaternion.Euler(0, 360 * Time.deltaTime * -1, 0);
                        break;
                }
                if (d > 20)
                    far = true;
            }
            
            if (far)
                speed = d / 1.2f;
        }
        RaycastHit left;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left + Vector3.forward), out left, 40))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left + Vector3.forward) * left.distance, Color.red);
            l = Vector3.Distance(transform.position, left.point);
            if(l < 5)
                Turn(turnForce * 2);
        }

        RaycastHit right;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right + Vector3.forward), out right, 40))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right + Vector3.forward) * right.distance, Color.blue);
            r = Vector3.Distance(transform.position, right.point);
            
            if (l < 5)
                Turn(turnForce * 2 * -1);
        }
        if (far)
        {
            if (r > l)
                Turn(turnForce);
            if (l > r)
                Turn(turnForce * -1);
        }
    }

    public void Move(float value)
    {
        transform.position += transform.forward * Time.deltaTime * value;
    }

    public void Turn(int value)
    {
        transform.rotation *= Quaternion.Euler(0, value * Time.deltaTime, 0);
    }

}
