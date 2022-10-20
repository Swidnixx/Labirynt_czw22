using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public virtual void Pick()
    {
        Debug.Log("Podniesiono " + this.GetType());
        Destroy(gameObject);
    }
}
