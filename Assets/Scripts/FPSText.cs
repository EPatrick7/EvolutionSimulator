using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FPSText : MonoBehaviour
{
    public int FPS = 0;

    public int FPSSample;

    private void Start()
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(1);
        FPS = FPSSample+6;
        FPSSample = 0;
        StartCoroutine(Delay());
    }
    private void Update()
    {
        if (FPS >= 50)
            this.GetComponent<TextMeshPro>().color = Color.green;
        else if (FPS>=30)
            this.GetComponent<TextMeshPro>().color = Color.yellow;
        else if (FPS < 30)
            this.GetComponent<TextMeshPro>().color = Color.red;
        this.GetComponent<TextMeshPro>().text = FPS + "";
        FPSSample++;
    }
}
