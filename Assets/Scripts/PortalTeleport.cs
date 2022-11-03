using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{

    [HideInInspector]public Transform receiver;
    Transform player;

    bool playerIsPassing;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player enter portal");
            playerIsPassing = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exit portal");
            playerIsPassing = false;
        }
    }

    private void FixedUpdate()
    {
        Vector3 portalToPlayer = player.position - transform.position;
        Debug.DrawLine(transform.position, transform.position + portalToPlayer, Color.green);
        Debug.DrawLine(transform.position, transform.position + transform.up);

        if (playerIsPassing)
        {
            float similarity = Vector3.Dot(portalToPlayer, transform.up);
            if (similarity < 0)
            {
                player.position = receiver.position;
                player.forward = receiver.up;
                playerIsPassing = false;
            }

        }
    }
}
