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
        if(other.CompareTag("Player") && !alreadyOpen)
        {
            playerInRange = true;
            GameManager.SingleInstance.infoText.text = "Press E to use a Key";

            Color color = Color.white;
            switch(keyColor)
            {
                case KeyColor.Gold:
                    color = Color.yellow;
                    break;

                case KeyColor.Green:
                    color = Color.green;
                    break;

                case KeyColor.Red:
                    color = Color.red;
                    break;
            }
            GameManager.SingleInstance.infoText.color = color;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !alreadyOpen)
        {
            playerInRange = false;
            GameManager.SingleInstance.infoText.text = "";
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
                    GameManager.SingleInstance.infoText.text = "";
                }
                else
                {
                    GameManager.SingleInstance.infoText.text = "You need a proper key";
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
