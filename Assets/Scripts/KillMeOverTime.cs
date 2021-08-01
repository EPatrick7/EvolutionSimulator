using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMeOverTime : MonoBehaviour
{
    public float Time=1;
    
    private void Awake()
    {

        Destroy(this.gameObject, Time);
    }
}
