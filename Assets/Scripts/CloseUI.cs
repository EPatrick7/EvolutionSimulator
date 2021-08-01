using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUI : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        this.transform.parent.position = new Vector3(10000, 10000, 1);
        this.transform.parent.name += "ClosedUI";
    }
    private void OnMouseDown()
    {
        this.transform.parent.position = new Vector3(10000, 10000, 1);
        this.transform.parent.name += "ClosedUI";
    }
}
