using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSearch : MonoBehaviour
{
    public GameObject Glass;
    public static bool Search = false;
    public Color Norm;
    public Color Over;
    private void OnMouseDown()
    {
        Search = !Search;
    }
    private void OnMouseEnter()
    {
        this.GetComponent<SpriteRenderer>().color = Over;   
    }
    private void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().color = Norm;
    }
    void Update()
    {
        Glass.GetComponent<Collider2D>().enabled = Search;
        if(Search)
        {
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Glass.transform.position = new Vector3(MousePos.x, MousePos.y, Glass.transform.position.z);
        }
        else
        {
            Glass.transform.localPosition = Vector3.zero + new Vector3(0, 0, Glass.transform.localPosition.z);
        }
    }
}
