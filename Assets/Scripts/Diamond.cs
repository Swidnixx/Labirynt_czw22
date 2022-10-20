using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Pickup
{
    public override void Pick()
    {
        GameManager.SingleInstance.AddDiamond();
        base.Pick();
    }
}
