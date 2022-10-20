using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Pickup
{
    public int time = 10;

    public override void Pick()
    {
        GameManager.SingleInstance.Freeze(time);
        base.Pick();
    }
}
