using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor
{
    Gold,
    Green,
    Red
}

public class Key : Pickup
{
    public KeyColor keyColor;

    public override void Pick()
    {
        GameManager.SingleInstance.AddKey(keyColor);
        base.Pick();
    }
}
