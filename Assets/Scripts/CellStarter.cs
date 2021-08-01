using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellStarter : MonoBehaviour
{
    public static bool GraphicLock=false;
    public static int GraphicsLevel=3;
    public Chromosome me;
    private void Start()
    {
        me = this.GetComponent<Chromosome>();
        CorrectState();
    }



    public void CorrectState()
    {

   //     this.transform.localScale = new Vector3(me.Size, me.Size, 1);
        foreach (Transform c in this.transform)
        {
            c.gameObject.SetActive(false);
        }
        if (!me.Bacteria)
        {

            if(GraphicsLevel>=1)
            this.transform.Find("Nucleus").gameObject.SetActive(true);

            this.transform.Find("Membrane").gameObject.SetActive(true);



            if (GraphicsLevel >= 2)
            {
                if (me.Speed >= 1)
                    this.transform.Find("FM").gameObject.SetActive(true);
                if (me.Speed >= 14)
                    this.transform.Find("FR").gameObject.SetActive(true);
                if (me.Speed >= 20)
                    this.transform.Find("FL").gameObject.SetActive(true);
            }
            /*
            for(int i = 1; i < me.FoodEfficency; i++)
            this.transform.Find("Mitochondria (" + (me.FoodEfficency-1)+ ")").gameObject.SetActive(true);
            */

            if (GraphicsLevel >= 3)
            {
                if (me.FoodEfficency >= 1)
                    this.transform.Find("Mitochondria (0)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 6)
                    this.transform.Find("Mitochondria (1)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 9)
                    this.transform.Find("Mitochondria (2)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 11)
                    this.transform.Find("Mitochondria (3)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 12)
                    this.transform.Find("Mitochondria (4)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 15)
                    this.transform.Find("Mitochondria (5)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 16)
                    this.transform.Find("Mitochondria (6)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 19)
                    this.transform.Find("Mitochondria (7)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 20)
                    this.transform.Find("Mitochondria (8)").gameObject.SetActive(true);
            }


            if (GraphicsLevel >= 2)
            {
                if (me.FoodCapacity >= 1)
                    this.transform.Find("Vacule (0)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 2)
                    this.transform.Find("Vacule (1)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 3)
                    this.transform.Find("Vacule (2)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 4)
                    this.transform.Find("Vacule (3)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 5)
                    this.transform.Find("Vacule (4)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 6)
                    this.transform.Find("Vacule (5)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 7)
                    this.transform.Find("Vacule (6)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 8)
                    this.transform.Find("Vacule (7)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 9)
                    this.transform.Find("Vacule (8)").gameObject.SetActive(true);
            }
            if (GraphicsLevel >= 3)
            {
                if (me.Health >= 1)
                    this.transform.Find("Ribosome (0)").gameObject.SetActive(true);
                if (me.Health >= 2)
                    this.transform.Find("Ribosome (1)").gameObject.SetActive(true);
                if (me.Health >= 3)
                    this.transform.Find("Ribosome (2)").gameObject.SetActive(true);
                if (me.Health >= 4)
                    this.transform.Find("Ribosome (3)").gameObject.SetActive(true);
                if (me.Health >= 5)
                    this.transform.Find("Ribosome (4)").gameObject.SetActive(true);
                if (me.Health >= 6)
                    this.transform.Find("Ribosome (5)").gameObject.SetActive(true);
                if (me.Health >= 7)
                    this.transform.Find("Ribosome (6)").gameObject.SetActive(true);
                if (me.Health >= 8)
                    this.transform.Find("Ribosome (7)").gameObject.SetActive(true);
                if (me.Health >= 9)
                    this.transform.Find("Ribosome (8)").gameObject.SetActive(true);
            }
        }
        else
        {
            if (GraphicsLevel >= 1)
                this.transform.Find("DNA").gameObject.SetActive(true);
            this.transform.Find("Membrane").gameObject.SetActive(true);
            if (GraphicsLevel >= 3)
            {
                if (me.FoodEfficency >= 1)
                    this.transform.Find("Nucleiod (0)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 5)
                    this.transform.Find("Nucleiod (1)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 8)
                    this.transform.Find("Nucleiod (2)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 9)
                    this.transform.Find("Nucleiod (3)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 10)
                    this.transform.Find("Nucleiod (4)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 11)
                    this.transform.Find("Nucleiod (5)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 15)
                    this.transform.Find("Nucleiod (6)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 17)
                    this.transform.Find("Nucleiod (7)").gameObject.SetActive(true);
                if (me.FoodEfficency >= 20)
                    this.transform.Find("Nucleiod (8)").gameObject.SetActive(true);
            }

            if (GraphicsLevel >= 3)
            {
                if (me.Health >= 1)
                    this.transform.Find("Nucleiod (9)").gameObject.SetActive(true);
                if (me.Health >= 2)
                    this.transform.Find("Nucleiod (10)").gameObject.SetActive(true);
                if (me.Health >= 3)
                    this.transform.Find("Nucleiod (11)").gameObject.SetActive(true);
                if (me.Health >= 4)
                    this.transform.Find("Nucleiod (12)").gameObject.SetActive(true);
                if (me.Health >= 5)
                    this.transform.Find("Nucleiod (13)").gameObject.SetActive(true);
                if (me.Health >= 6)
                    this.transform.Find("Nucleiod (14)").gameObject.SetActive(true);
                if (me.Health >= 7)
                    this.transform.Find("Nucleiod (15)").gameObject.SetActive(true);
                if (me.Health >= 8)
                    this.transform.Find("Nucleiod (16)").gameObject.SetActive(true);
                if (me.Health >= 9)
                    this.transform.Find("Nucleiod (17)").gameObject.SetActive(true);
            }

            if (GraphicsLevel > 2)
            {
                if (me.FoodCapacity >= 1)
                    this.transform.Find("Vacule (9)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 2)
                    this.transform.Find("Vacule (10)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 3)
                    this.transform.Find("Vacule (11)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 4)
                    this.transform.Find("Vacule (12)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 5)
                    this.transform.Find("Vacule (13)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 6)
                    this.transform.Find("Vacule (14)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 7)
                    this.transform.Find("Vacule (15)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 8)
                    this.transform.Find("Vacule (16)").gameObject.SetActive(true);
                if (me.FoodCapacity >= 9)
                    this.transform.Find("Vacule (17)").gameObject.SetActive(true);
            }

            if (GraphicsLevel >= 2)
            {
                if (me.Speed >= 9)
                    this.transform.Find("FL").gameObject.SetActive(true);
                if (me.Speed >= 1)
                    this.transform.Find("FLM").gameObject.SetActive(true);
                if (me.Speed >= 5)
                    this.transform.Find("FRM").gameObject.SetActive(true);
                if (me.Speed >= 15)
                    this.transform.Find("FR").gameObject.SetActive(true);
            }
        }


        if(GraphicLock)
        {
            foreach(Transform c in this.transform)
            {
                if(c.gameObject.active==false&&c.gameObject.tag!="Vacule")
                {
                    Destroy(c.gameObject);
                }
            }
        }
    }


}
