using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hirachy : MonoBehaviour
{
    public static BloonType[] GetChildren(BloonType parent)
    {
        List<BloonType> children = new List<BloonType>();
        foreach (Transform child in parent.transform)
        {
            if (child.GetComponent<BloonType>())
            {
                children.Add(child.GetComponent<BloonType>());
            }
        }
        return children.ToArray();
    }
}
