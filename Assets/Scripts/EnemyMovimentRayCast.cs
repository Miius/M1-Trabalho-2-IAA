using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovimentRayCast : MonoBehaviour
{
    bool far = true;
    int speed = 10;
    int turnForce = 10;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            Turn(turnForce * -1);
        if (Input.GetKey(KeyCode.RightArrow))
            Turn(turnForce);

        RaycastForward();
        RaycastRight();
        RaycastLeft();

        if (far)
            Move();
        else
            transform.position += transform.forward * Time.deltaTime * speed * -1;
    }

    void RaycastForward()
    {
        RaycastHit forward;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out forward, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * forward.distance, Color.yellow);
            float d = Vector3.Distance(transform.position, forward.point);
            Debug.Log(d);
            if (d >= 5)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * forward.distance, Color.white);
                far = true;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * forward.distance, Color.red);
                far = false;
            }

        }
    }

    void RaycastLeft()
    {
        RaycastHit left;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left + Vector3.forward), out left, Mathf.Infinity))
        {
            float d = Vector3.Distance(transform.position, left.point);
            if (d >= 10)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left + Vector3.forward) * left.distance, Color.white);
                Turn(-50);
                //transform.rotation *= Quaternion.Euler(0, -90, 0);
            }
            else
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left + Vector3.forward) * left.distance, Color.red);
        }
    }


    void RaycastRight()
    {
        RaycastHit right;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right + Vector3.forward),
                out right, Mathf.Infinity))
        {

            float d = Vector3.Distance(transform.position, right.point);
            //Debug.Log(d);
            if (d >= 10)
            {
                Turn(50);
                Debug.DrawRay(transform.position,
                    transform.TransformDirection(Vector3.right + Vector3.forward) * right.distance, Color.blue);
            }
            else
            {

                Debug.DrawRay(transform.position,
                    transform.TransformDirection(Vector3.right + Vector3.forward) * right.distance, Color.red);
            }
        }
    }

    void Move()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    void Turn(int value)
    {
        transform.rotation *= Quaternion.Euler(0, value * Time.deltaTime, 0);
    }

}
