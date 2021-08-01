using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private bool GizmoMode=true;
    private void OnDrawGizmos()
    {
        if (GizmoMode)
            this.GetComponent<SpriteRenderer>().enabled = false;
        else
            this.GetComponent<SpriteRenderer>().enabled = true;
    }
    private void Start()
    {
        GizmoMode = false;
        this.GetComponent<SpriteRenderer>().enabled = true;
    }
    void Update()
    {
        if (this.GetComponent<SpriteRenderer>().color.a>0.02f)
        this.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.005f);
    }
}
