using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloonType : Bloon
{
    public BloonType[] children;
    public float speed = 5f;

    private void Update()
    {
        SeekPlayer(speed);
    }

    public override void SeekPlayer(float speed)
    {
        print("Blon");
        base.SeekPlayer(speed);
    }
}
