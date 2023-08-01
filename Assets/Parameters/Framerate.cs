using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public enum limits
    {
        noLimit = 0,
        limit30 = 30,
    }

    public limits limit;

    void Awake()
    {
        Application.targetFrameRate = (int)limit;
    }
}
