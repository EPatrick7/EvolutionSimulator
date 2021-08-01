using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneSelect : MonoBehaviour
{
    public static int Choice=1;
    public int TypeID;
    private void Update()
    {
        if (Choice == TypeID)
            this.GetComponent<ButtonClick>().State = true;
        else
            this.GetComponent<ButtonClick>().State = false;

        this.GetComponent<ButtonClick>().Refresh();
    }
    private void OnMouseDown()
    {
        Choice = TypeID;
    }
}
