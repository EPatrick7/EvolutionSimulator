using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickState : MonoBehaviour
{
    public int Id;
    public static bool ClusterPlant = true;
    private void Update()
    {
        if (Id == 5)
            this.GetComponent<ButtonClick>().State = ClusterPlant;
        if(Id==6)
            this.GetComponent<ButtonClick>().State = !ClusterPlant;
        if (Id == 5 || Id == 6)
            this.GetComponent<ButtonClick>().Refresh();
    }
    private void OnMouseDown()
    {
        if (Id == 0)
            CellManager.noPart = !CellManager.noPart;
        if (Id == 1)
            MoveCamera.hideonunfocus = !MoveCamera.hideonunfocus;
        if (Id == 2)
            CellStarter.GraphicLock = true;
        if (Id == 3)
        {
            foreach(Chromosome g in GameObject.FindObjectsOfType<Chromosome>())
            {
                if (!g.Bacteria)
                    Destroy(g.gameObject);
            }
            this.GetComponent<SpriteRenderer>().color = Color.gray;

            Destroy(this.GetComponent<ButtonClick>());

        }
        if(Id==4)
        {
            CellManager.imaturity = !CellManager.imaturity;
        }
        if(Id==5||Id==6)
        {
            ClusterPlant = !ClusterPlant;
        }
        if(Id==7)
        {
            Sim = false;
            this.GetComponent<SpriteRenderer>().color = Color.gray;

            Destroy(this.GetComponent<ButtonClick>());
        }
        if(!Sim)
        {
           foreach(Graph g in GameObject.FindObjectsOfType<Graph>())
            {
                if(g.transform.parent!=null)
                {
                    Destroy(g.transform.parent.gameObject);
                }
            }
        }
    }
    public static bool Sim=true;
}
