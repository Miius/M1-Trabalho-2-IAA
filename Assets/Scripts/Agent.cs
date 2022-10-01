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
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Move(speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Move(speed * -1);
        }
    }

    
    
        public void Move(int value)
        {
            transform.position += transform.forward * Time.deltaTime * value;
        }
        public void Turn(int value)
        {
            transform.rotation *= Quaternion.Euler(0, value * Time.deltaTime, 0);
        }

}


