using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnReset : MonoBehaviour
{
    void Update()
    {
        this.GetComponent<ParticleSystem>().enableEmission = Reset.ResetTime;
    }
}
