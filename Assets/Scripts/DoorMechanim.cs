using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanim : MonoBehaviour
{
    public Transform door;
    public Transform closedPos;
    public Transform openPos;

    public float speed = 1;

    public bool open;

    private void Update()
    {
        if(open)
        {
            door.position = Vector3.MoveTowards(door.position, openPos.position, speed * Time.deltaTime);//openPos.position;
        }

        if(!open)
        {
            door.position = Vector3.MoveTowards(door.position, closedPos.position, speed * Time.deltaTime);
        }
    }
}
