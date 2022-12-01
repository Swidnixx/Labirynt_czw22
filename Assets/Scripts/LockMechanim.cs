using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanim : MonoBehaviour
{
    public KeyColor keyColor;       // pasuj¹cy klucz
    public DoorMechanim[] doorToOpen;
    bool playerInRange;
    bool alreadyOpen = false;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (!alreadyOpen && playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (CheckTheKey())
                {
                    alreadyOpen = true;
                    animator.SetTrigger("open");
                }
                else
                {
                    Debug.Log("Brak pasuj¹cego klucza");
                }
            } 
        }
    }

    bool CheckTheKey()
    {
        switch(keyColor)
        {
            case KeyColor.Green:
               if( GameManager.SingleInstance.greenKeys > 0 )
                {
                    GameManager.SingleInstance.greenKeys--;
                    return true;
                }
                break;

            case KeyColor.Red:
                if (GameManager.SingleInstance.redKeys > 0)
                {
                    GameManager.SingleInstance.redKeys--;
                    return true;
                }
                break;

            case KeyColor.Gold:
                if (GameManager.SingleInstance.goldKeys > 0)
                {
                    GameManager.SingleInstance.goldKeys--;
                    return true;
                }
                break;

        }
        return false;
    }

    public void Open()
    {
        foreach(DoorMechanim d in doorToOpen)
        {
           d.open = true;
        }
    }
}
