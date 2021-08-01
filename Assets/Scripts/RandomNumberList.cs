using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumberList : MonoBehaviour
{
    public static int[] RandNumb;
    public static int parse=0;

    public int[] RandNumbVis;

    public int Scale = 1;
    public int Length=100;


    private void Update()
    {
        this.transform.localScale = new Vector3(Camera.main.orthographicSize, Camera.main.orthographicSize, 1);
    }


    private void Start()
    {

        RandNumb = new int[Length];

        for(int i =0; i < Length;i++)
        {
            RandNumb[i] = Random.Range(-Scale, Scale+1);
        }
        RandNumbVis = RandNumb;
    }

    public static int GetNumber()
    {
        if (RandNumb.Length > 0)
        {
            int val = 0;

            val = RandNumb[parse];

            parse++;
            if (parse >= RandNumb.Length)
                parse = 0;


            return val;
        }
        else
            return 0;
    }

}
