using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCell : MonoBehaviour
{
    public GameObject Object;
    public int TargetNum;
    void Update()
    {
        if (TargetNum > 0)
        {
            SpawnCell();
            TargetNum--;
                
          }
        if (TargetNum > 0)
        {
            SpawnCell();
            TargetNum--;

        }
        if (TargetNum > 0)
        {
            SpawnCell();
            TargetNum--;

        }
        if (TargetNum > 0)
        {
            SpawnCell();
            TargetNum--;

        }
    }

    public void SpawnCell()
    {


            Vector3 SpawnPos;


            SpawnPos = Random.insideUnitCircle * WorldBorder.Me.Size * 4;
            int i = 0;
            while (Vector2.Distance(new Vector2(0, 0), new Vector2(SpawnPos.x, SpawnPos.y)) > WorldBorder.Me.Size * 2.4 && i < 1000)
            {
                i++;
                SpawnPos = Random.insideUnitCircle * WorldBorder.Me.Size * 4;
            }
            if (i < 1000)
            {

            GameObject g = null;
                if (!Physics2D.OverlapCircle(SpawnPos, 0.1f))
                    g = Instantiate(Object, SpawnPos, this.transform.rotation);
                if(g!=null)
            {
                g.name = "StartCell";
            }
            }
        }
}
