using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DayManager : MonoBehaviour
{
    public static int Day=1;

    public static int Hour = 0;
    public static float Min=0;


    private void FixedUpdate()
    {
        Min += 1 * Time.timeScale;

        if(Min/60>=1)
        {
            Hour++;
        }
        if(Hour%24==0&& Min / 60 >= 1)
        {
            Day++;
            
        }
        if(Hour>=10)
        this.GetComponent<TextMeshPro>().text = " " + Day + " Time: " + Hour + ":" + ((int)Min);
        else
            this.GetComponent<TextMeshPro>().text = " " + Day + " Time: " + "0"+ Hour + ":" + ((int)Min);

        if (Min / 60 >= 1)
            Min = 0;
        if (Hour % 24 == 0)
            Hour = 1;
    }
}
