using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Pickup
{
    public int time = 10;

    public override void Pick()
    {
        GameManager.SingleInstance.AddTime(time);
        base.Pick();
    }
}
