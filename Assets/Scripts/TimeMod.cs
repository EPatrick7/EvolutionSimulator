using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMod : MonoBehaviour
{
    [Range(0,3)]
    public float Time=1;
    void Update()
    {
        UnityEngine.Time.timeScale = Time;
    }
}
