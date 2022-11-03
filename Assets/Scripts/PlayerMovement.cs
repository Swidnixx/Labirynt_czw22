using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;

    [SerializeField]
    CharacterController controller;

    [SerializeField]
    Transform groundSensor;
    [SerializeField]
    LayerMask groundLayer;

    float velocityY;
    private void Update()
    {
        Steering();
        bool grounded = GroundCheck();

        Gravity(grounded);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.CompareTag("Pickup"))
        {
            hit.gameObject.GetComponent<Pickup>().Pick();
        }
    }

    void Gravity(bool grounded)
    {
        if (grounded)
        {
            velocityY = 0;
        }
        else
        {
            if (velocityY > -55)
            {
                velocityY -= 10 * Time.deltaTime;
            }

            controller.Move(new Vector3(0, velocityY, 0) * Time.deltaTime);
        }
    }

    bool GroundCheck()
    {
        RaycastHit hit;
        bool didHit = Physics.Raycast( groundSensor.position, Vector3.down, out hit, 0.5f, groundLayer);
        if (didHit)
        {
            //Debug.Log(hit.collider);

            string tag = hit.collider.tag;

            switch(tag)
            {
                case "FastFloor":
                    speed = 20;
                    break;

                case "SlowFloor":
                    speed = 4;
                    break;

                default:
                    speed = 10;
                    break;
            }
        }

        return didHit;
    }
    void Steering()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //Debug.Log( new Vector2(inputX, inputY) );

        Vector3 movement = transform.forward * inputY + transform.right * inputX;
        Debug.DrawLine(transform.position, transform.position + transform.forward, Color.blue);
        controller.Move(movement * speed * Time.deltaTime);
    }
}
