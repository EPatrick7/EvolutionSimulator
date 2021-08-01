using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpawn : MonoBehaviour
{
    public GameObject Object;
    private string Name;
    private void Start()
    {
        if(Object!=null)
        Name = Object.name;
        else
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnMouseDown()
    {
        bool ok = true;
        foreach (Drag g in GameObject.FindObjectsOfType<Drag>())
        {
            if (g != null)
            {
                if (g.name == Name)
                    ok = false;
            }
        }
        if (ok)
        {
            GameObject g = Object;
            g.transform.position = this.transform.position;
            g.name = Name;
            g.transform.localPosition += new Vector3(-110, -110, 0);
        }
    }
    private void LateUpdate()
    {

        bool ok = true;
        foreach (Drag g in GameObject.FindObjectsOfType<Drag>())
        {
            if (g != null)
            {
                if (g.name == Name)
                    ok = false;
            }
        }
        if (!ok)
            this.GetComponent<SpriteRenderer>().color = Color.gray;
        else
            this.GetComponent<SpriteRenderer>().color = Color.green;
        if (Object == null)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(this.GetComponent<ButtonSpawn>());
        }
    }

}
