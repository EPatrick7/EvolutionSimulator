using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public bool NoChange;
    public bool NOHover;
    public bool NoClick;
    public Sprite Clicked;
    public Sprite Norm;
    public GameObject Object;
    public bool State;
    private void OnMouseOver()
    {
        if(!NOHover)
        this.GetComponent<SpriteRenderer>().sprite = Clicked;
    }
         public void Refresh()
    {
        if (State)
            this.GetComponent<SpriteRenderer>().sprite = Clicked;
        else
            this.GetComponent<SpriteRenderer>().sprite = Norm;
    }
    private void OnMouseDown()
    {
        if (!NoClick)
        {
            if (!NoChange)
                State = !State;
            else
                State = true;
        }
    }
    private void Update()
    {
        if(Object != null)
        {
            Object.gameObject.SetActive(State);
        }
    }
    private void OnMouseExit()
    {
        if (State)
            this.GetComponent<SpriteRenderer>().sprite = Clicked;
        else
            this.GetComponent<SpriteRenderer>().sprite = Norm;
    }
}
