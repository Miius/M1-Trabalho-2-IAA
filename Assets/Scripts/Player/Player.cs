using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;

    public float speed;
    public float gravity = -9.81f;
    private Vector3 velocity;
    
    #region GroundLogic
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    private bool isGrounded;
    #endregion
    
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Movement
        // Move();
        // Fall();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(PowerUp());
        }
    }

    IEnumerator PowerUp()
    {
        SubjectPlayer.instance.NotifyObserver("coletou");
        yield return new WaitForSeconds(10.0f);
        SubjectPlayer.instance.NotifyObserver("liberou");
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    void Fall()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        //GroundLogic
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
    }
}
