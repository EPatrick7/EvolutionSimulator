using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopChecker : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        this.GetComponent<TextMeshPro>().text = "" + GameObject.FindObjectsOfType<Chromosome>().Length;
       foreach (Chromosome g in GameObject.FindObjectsOfType<Chromosome>())
        {
            if (!g.enabled)
                Destroy(g.gameObject);
        }
        StartCoroutine(Delay());
    }
}
