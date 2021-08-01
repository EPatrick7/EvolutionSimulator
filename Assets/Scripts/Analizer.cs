 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Analizer : MonoBehaviour
{
    public static Chromosome Selected;
    public GameObject Glass;



    public Slider Size;
    public Slider Speed;
    public Slider Vision;
    public Slider Health;
    public Slider Attack;
    public Slider Efficiency;


    public Slider Capacity;
    public Slider ReproductiveReq;

    public TextMeshPro Species;
    public Toggle Prokaryote;
    void Update()
    {
        if(Selected!=null)
        {
            Size.value = Mathf.Round(Selected.Size);
            Size.transform.Find("PROP").GetComponent<TextMeshPro>().text = "Size: " + Size.value;
            Speed.value = Mathf.Round(Selected.Speed);
            Speed.transform.Find("PROP").GetComponent<TextMeshPro>().text = "Speed: " + Speed.value;
            Vision.value = Mathf.Round(Selected.SenseRange);
            Vision.transform.Find("PROP").GetComponent<TextMeshPro>().text = "Vision: " + Vision.value;
            Health.value = Mathf.Round(Selected.Health);
            Health.transform.Find("PROP").GetComponent<TextMeshPro>().text = "Health: " + Health.value;
            Attack.value = Mathf.Round((Selected.Attack*10));
            Attack.transform.Find("PROP").GetComponent<TextMeshPro>().text = "Attack: " + Attack.value;
            Efficiency.value = Mathf.Round(Selected.FoodEfficency);
            Efficiency.transform.Find("PROP").GetComponent<TextMeshPro>().text = "Efficiency: " + Efficiency.value;
            Capacity.value = Mathf.Round(Selected.FoodCapacity);
            Capacity.transform.Find("PROP").GetComponent<TextMeshPro>().text = "Food Capacity: " + Capacity.value;
            ReproductiveReq.value = Mathf.Round(Selected.ReproductiveUrge);
            ReproductiveReq.transform.Find("PROP").GetComponent<TextMeshPro>().text = "Reproductive Requirment: " + ReproductiveReq.value;
            Prokaryote.isOn = Selected.Bacteria;
            Species.text = "Species ID: "+Selected.SpeciesID;
        }
    }
}
