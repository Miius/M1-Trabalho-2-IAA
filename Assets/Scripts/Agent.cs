using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    bool far = true;
    public int speed;
    public int turnForce;
    float l, r;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Turn(turnForce * -1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Turn(turnForce);
        }

        Raycast();

        if (far)
        {
            Move();
        }
        else
        {
            Move();
           
        }
    }

    void Raycast()
    {
        RaycastHit forward;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out forward, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * forward.distance, Color.yellow);
            float d = Vector3.Distance(transform.position, forward.point);
            Debug.Log(d);
            if (d >= 10)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * forward.distance, Color.white);
                //far = true;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * forward.distance, Color.red);
                transform.position += transform.forward * Time.deltaTime * speed * 2 * -1;
                //far = false;
                //RaycastRight();
                //RaycastLeft();
            }
        }


        RaycastHit left;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left + Vector3.forward), out left, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left + Vector3.forward) * left.distance, Color.yellow);
            l = Vector3.Distance(transform.position, left.point);
           
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left + Vector3.forward) * left.distance, Color.red);
                if (l > r)
                {                  
                    Turn(turnForce * -1);
                }
            
        }


        RaycastHit right;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right + Vector3.forward), out right, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right + Vector3.forward) * right.distance, Color.yellow);
            r = Vector3.Distance(transform.position, right.point);
           
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right + Vector3.forward) * right.distance, Color.blue);
                if (r > l)
                {
                    Turn(turnForce);
                }
            
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


