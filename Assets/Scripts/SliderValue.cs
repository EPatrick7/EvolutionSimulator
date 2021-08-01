using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SliderValue : MonoBehaviour
{

    public static float ItemSize = 5;
    public static float Value=3;
    
    public static float Value2=25;
    public static float Value3 = 5;
    public static float Value4 = 2;
    public TextMeshPro Text;
    public GameObject Lock;

    public GameObject Fill;
    public GameObject Back;

    public int Type;

 

    private void Start()
    {
        CellStarter.GraphicLock = false;
        if(Type==0)
        this.GetComponent<Slider>().value = Value;
        else if (Type==1)
            this.GetComponent<Slider>().value = Chromosome.MutationRate;
        else if (Type==2)
            this.GetComponent<Slider>().value = ItemSize;

    }
    private bool known;
    void Update()
    {

        if (Type == 0)
        {
            if (Value <= 1)
                Lock.SetActive(true);
            else
                Lock.SetActive(false);




            this.GetComponent<Slider>().interactable = !CellStarter.GraphicLock;
            Text.text = "Level of Detail: " + Value;

            if (CellStarter.GraphicLock)
            {
                Fill.GetComponent<Image>().color = Color.gray;

                Back.GetComponent<Image>().color = Color.black;

                Text.text += " (Locked)";
                if (!known)
                {
                    known = true;
                    foreach (CellStarter g in GameObject.FindObjectsOfType<CellStarter>())
                    {
                        g.CorrectState();
                    }
                }
            }

            if (Value != this.GetComponent<Slider>().value)
            {
                Value = this.GetComponent<Slider>().value;

                CellStarter.GraphicsLevel = (int)Value;

                foreach (CellStarter g in GameObject.FindObjectsOfType<CellStarter>())
                {
                    g.CorrectState();
                }
            }
        }
        else if (Type == 1)
        {

            Text.text = "Mutation Rate: " + "1/" + Value2;

            if (Value2 != this.GetComponent<Slider>().value)
            {
                Value2 = this.GetComponent<Slider>().value;


                Chromosome.MutationRate = (int)this.GetComponent<Slider>().value;

            }
        }
        else if (Type == 2)
        {
            Text.text = "Cluster Size: " + Value3;

            if (Value3 != this.GetComponent<Slider>().value)
            {
                Value3 = this.GetComponent<Slider>().value;


                ItemSize = (int)this.GetComponent<Slider>().value;

            }
        }
        else if (Type == 3)
        {
            Text.text = "Food Rate: " + Value4;

            if (Value4 != this.GetComponent<Slider>().value)
            {
                Value4 = this.GetComponent<Slider>().value;


                FoodSpawn.speed = (int)this.GetComponent<Slider>().value;

            }
        }
    }
}
