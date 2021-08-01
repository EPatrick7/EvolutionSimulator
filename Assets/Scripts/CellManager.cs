using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public GameObject Prefab;
    public static bool imaturity=false;
    public static bool noPart=false;

    public GameObject Child;



    public GameObject Meat;
    public GameObject Death;
    public GameObject Birth;
    private Chromosome me;


    public float MaxEnergy=100;

    public float Energy;
    public int CurrentFood;
    public int EatID=0;

    public GameObject[] Vacules;
    public Sprite[] Foods;
    public Sprite Normal;

    private int FoodCheck;

    public float Health;

    public int age;

    private void Start()
    {
        me = this.GetComponent<Chromosome>();
        Health = me.Health;
   
        going = false;
        if (this.GetComponent<Rigidbody2D>().useAutoMass == false)
        {
            if (!me.Bacteria)
                this.GetComponent<Rigidbody2D>().mass = me.Size*2/20f;
            else
                this.GetComponent<Rigidbody2D>().mass = me.Size*3/4f;
        }
        age = 0;
    }
    
    private bool going;
    private bool going2;
    IEnumerator Grow()
    {


            going = true;   
        yield return new WaitForSeconds(0.2f);
        going = false;

        if (this.transform.localScale.x < me.Size)
        {
            this.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
        if (CurrentFood >= me.FoodCapacity - 1)
        {
            if (this.transform.localScale.x < me.Size)
            {
                this.transform.localScale += new Vector3(0.05f, 0.05f, 0);
            }
        }

    }
    IEnumerator Second()
    {
        going2 = true;
        yield return new WaitForSeconds(1);
        going2 = false;
        age++;
    }
    private void FixedUpdate()
    {

       
        if(!going)
        {

            if (this.transform.localScale.x < me.Size)
            {
                if (!imaturity)
                    StartCoroutine(Grow());
                else
                    this.transform.localScale = new Vector3(me.Size, me.Size,1);
            }
        }
        if (!going2)
        { 
                StartCoroutine(Second());
        }
        if (Energy < 0)
        {
            CurrentFood--;
            Energy = MaxEnergy;
        }
        if (!Dead)
        {
            if (Health <= 0)
                Die(true);
            if (CurrentFood <= -1)
                Die(false);
        }
        if (CurrentFood >= me.FoodCapacity && age >= 1)
        {
            if (this.transform.localScale.x >= me.Size)
                Replecate();
        }
        if (CurrentFood > me.FoodCapacity)
        {
            CurrentFood--;
        }
        FoodUpdate();
        if (FoodCheck < CurrentFood)
        {

            FoodCheck = CurrentFood;
      
            if (CurrentFood >= me.FoodCapacity/2)
            {
                if (Random.Range(0, Mathf.RoundToInt(me.ReproductiveUrge) + 1) == 0)
                {
                    
                   
                    if (this.transform.localScale.x >= me.Size&&age>=1)
                        Replecate();
                }
            }

        }
    }
    private bool Dead;
    public void Die(bool murder)
    {
        Dead = true;
     if(murder||true)
        {

                GameObject g2 = Instantiate(Meat, this.transform.position, this.transform.rotation);

                g2.transform.localScale = this.transform.localScale;
                if (me.Bacteria)
                    g2.transform.localScale *= 5;
                else
                   g2.transform.localScale /= 2;
           
          }
        if (!noPart)
        {
            GameObject g = Instantiate(Death, this.transform.position, this.transform.rotation);
            g.transform.localScale = this.transform.localScale;
            if (me.Bacteria)
                g.transform.localScale = this.transform.localScale / 2;
            else
            {
                g.transform.localScale = this.transform.localScale / 22;
            } 
            g.GetComponent<ParticleSystem>().startColor = this.transform.Find("Membrane").GetComponent<SpriteRenderer>().color;
        }
        this.GetComponent<CellAI>().StopAllCoroutines();
        StopAllCoroutines();
        Destroy(this.gameObject);

    }
    public void Replecate()
    {
        Energy = MaxEnergy*2;
        CurrentFood = 0;
        GameObject g = Instantiate(this.gameObject);
 
        Chromosome c = g.GetComponent<Chromosome>();
      
        if (Random.Range(0, Chromosome.MutationRate) == 0)
        {

            Chromosome.SpeciesAmount++;
            c.SpeciesID = Chromosome.SpeciesAmount;
            for (int i = 0; i < 3 + Random.Range(0, 6);i++)
            {
                int MutationID = (Random.Range(0, 7));

                if (MutationID == 0)
                    c.FoodCapacity += Random.Range(-0.5f, 0.5f);
                if (MutationID == 1)
                    c.ReproductiveUrge += Random.Range(-0.5f, 0.5f);
                if (MutationID == 2)
                    c.FoodEfficency += Random.Range(-0.5f, 0.5f);
                if (MutationID == 3)
                    c.Speed += Random.Range(-0.25f, 0.25f);
                if (MutationID == 4)
                    c.Health += Random.Range(-0.25f, 0.25f);
                if (MutationID == 5)
                    c.SenseRange += Random.Range(-0.25f, 0.25f);
                if (MutationID == 6)
                    c.Size += Random.Range(-0.25f, 0.25f);
            }
            g.transform.Find("Membrane").GetComponent<SpriteRenderer>().color=Random.ColorHSV();
        }
        Child = g;
        g.GetComponent<CellManager>().Child = this.gameObject;
        age = 0;
        if (!noPart)
        {
            GameObject g2 = Instantiate(Birth, this.transform.position, this.transform.rotation);
            g2.transform.localScale /= 2;
            g2.GetComponent<ParticleSystem>().startColor = this.transform.Find("Membrane").GetComponent<SpriteRenderer>().color;
            if (me.Bacteria)
                g2.transform.localScale = this.transform.localScale / 2;
        }
        g.name = "Cell (" + g.GetComponent<Chromosome>().SpeciesID +")";
        g.transform.localScale = this.transform.localScale / 2;
        this.transform.localScale = g.transform.localScale;
        g.transform.position += new Vector3(RandomNumberList.GetNumber()*2, RandomNumberList.GetNumber()*2, 0);

    }
 
        public void FoodUpdate()
    {
        if (EatID < 0 || EatID > 1)
            EatID = 0;

        if (CellStarter.GraphicsLevel >= 3)
        {
            foreach (GameObject g in Vacules)
            {
                if (g != null)
                    g.GetComponent<SpriteRenderer>().sprite = Normal;
            }

            if (CurrentFood >= 1)
            {
                Vacules[0].GetComponent<SpriteRenderer>().sprite = Foods[EatID];
            }
            if (CurrentFood >= 2)
            {
                Vacules[1].GetComponent<SpriteRenderer>().sprite = Foods[EatID];
            }
            if (CurrentFood >= 3)
            {
                Vacules[2].GetComponent<SpriteRenderer>().sprite = Foods[EatID];
            }
            if (CurrentFood >= 4)
            {
                Vacules[3].GetComponent<SpriteRenderer>().sprite = Foods[EatID];
            }
            if (CurrentFood >= 5)
            {
                Vacules[4].GetComponent<SpriteRenderer>().sprite = Foods[EatID];
            }
            if (CurrentFood >= 6)
            {
                Vacules[5].GetComponent<SpriteRenderer>().sprite = Foods[EatID];
            }
            if (CurrentFood >= 7)
            {
                Vacules[6].GetComponent<SpriteRenderer>().sprite = Foods[EatID];
            }
            if (CurrentFood >= 8)
            {
                Vacules[7].GetComponent<SpriteRenderer>().sprite = Foods[EatID];
            }
            if (CurrentFood >= 9)
            {
                Vacules[8].GetComponent<SpriteRenderer>().sprite = Foods[EatID];
            }
        }
    }
}
