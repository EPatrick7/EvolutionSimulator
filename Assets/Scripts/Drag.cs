using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool clicked;
    private int scalex = 129;
    private int scaley = 105;
    private bool old;
    private bool visible;
    private void Start()
    {
  
     
    }

    private void OnMouseDrag()
    {
        clicked = true;
        this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, this.transform.position.z);
    }
    private void Update()
    {
        if(!clicked)
            {
            this.transform.localPosition = new Vector3((Mathf.RoundToInt(this.transform.localPosition.x)), Mathf.RoundToInt((this.transform.localPosition.y)), this.transform.localPosition.z);

        }
    }
    private void OnMouseUp()
    {
        clicked = false;
    
        this.transform.localPosition = new Vector3((Mathf.RoundToInt(this.transform.localPosition.x)), Mathf.RoundToInt((this.transform.localPosition.y )) , this.transform.localPosition.z);
      
    }
    
}
