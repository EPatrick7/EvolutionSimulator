using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemPlacer : MonoBehaviour
{
    public GameObject Meat;
    public GameObject Plant;
    public static KeyCode Place2 = KeyCode.LeftShift;
    private void Update()
    {

        this.GetComponent<TextMeshPro>().text = Place2 + " + Click: Place Item";
        if(Input.GetKey(Place2)&&Input.GetMouseButtonDown(0))
        {
            Vector3 Spawnpos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, GameObject.FindGameObjectWithTag("FoodP").transform.position.z);

            for(int i =0; i< SliderValue.ItemSize;i++)
            {
                if (ClickState.ClusterPlant)
                    Instantiate(Plant, Spawnpos+ new Vector3(RandomNumberList.GetNumber()/2.0f, RandomNumberList.GetNumber()/ 2.0f, 0), this.transform.rotation);
                else
                    Instantiate(Meat, Spawnpos + new Vector3(RandomNumberList.GetNumber() / 2.0f, RandomNumberList.GetNumber() / 2.0f, 0), this.transform.rotation);
            }
        }
    }
}
