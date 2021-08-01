using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSelect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Chromosome>()!=null)
        {
            Analizer.Selected = collision.GetComponent<Chromosome>();
        }
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
         if (Mathf.Abs(this.transform.localPosition.magnitude)>5)
                GlassSearch.Search = false;
    }
}
