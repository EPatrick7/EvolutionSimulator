using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public static bool ResetTime;
    public bool close;

    private void OnMouseDown()
    {

        if (close)
            Application.Quit();
        ResetTime = true;
    }
    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        ResetTime = false;
        DayManager.Day = 0;
        DayManager.Hour = 0;
        DayManager.Min = 0;
        Chromosome.SpeciesAmount = 2;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Update()
    {
        if(ResetTime)
        {
            Time.timeScale = 1;
            StartCoroutine(Delay());
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, WorldBorder.Me.Size * 3, 0.1f);
            Camera.main.transform.GetComponent<MoveCamera>().enabled = false;
            if(Camera.main.orthographicSize>= (WorldBorder.Me.Size * 3)-2)
               Camera.main.transform.position += new Vector3(-2, 0, 0);
        }
    }
}
