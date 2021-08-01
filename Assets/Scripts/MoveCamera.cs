using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public static bool hideonunfocus;


    public static KeyCode Forward=KeyCode.W;
    public static KeyCode Backward = KeyCode.S;
    public static KeyCode Left = KeyCode.A;
    public static KeyCode Right = KeyCode.D;
    public static KeyCode Fast = KeyCode.LeftShift;

    public static KeyCode Fullscreen = KeyCode.F11;
    public int speednorm;
    private bool FocusNow=true;
    private void OnApplicationFocus(bool focus)
    {
        FocusNow = focus;
        if (!focus&&hideonunfocus)
            Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 100);
        else
            Camera.main.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,-10);
    }

    void Update()
    {


        int speed = speednorm;
        if (Input.GetKey(Fast))
            speed *= 2;
        if(Input.GetKeyDown(Fullscreen))
            Screen.fullScreen = !Screen.fullScreen;

        if (Input.GetKey(Forward))
        {
            this.GetComponent<Rigidbody2D>().AddForce(this.transform.up * speed);
        }
        if (Input.GetKey(Backward))
        {
            this.GetComponent<Rigidbody2D>().AddForce(this.transform.up * -speed);
        }
        if (Input.GetKey(Right))
        {
            this.GetComponent<Rigidbody2D>().AddForce(this.transform.right * speed);
        }
        if (Input.GetKey(Left))
        {
            this.GetComponent<Rigidbody2D>().AddForce(this.transform.right * -speed);
        }

        this.GetComponent<Camera>().orthographicSize += Input.GetAxis("Mouse ScrollWheel")*100;
        this.GetComponent<Camera>().orthographicSize += Input.GetAxis("Scroll")*100;

            if (this.GetComponent<Camera>().orthographicSize < 5)
                this.GetComponent<Camera>().orthographicSize = 5;
        if (this.GetComponent<Camera>().orthographicSize > WorldBorder.Me.Size * 5)
            this.GetComponent<Camera>().orthographicSize = WorldBorder.Me.Size * 5;
    }
}
