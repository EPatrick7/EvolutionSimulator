using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public static int speed;
    public int Speed=10;
    public int Food = 100;
    public GameObject FoodP;
    private bool Old;
    private void Start()
    {

        speed = Speed;
    }
    void Update()
    {
        Speed = speed;
        if (!Old)
        {
            for (int i = 0; i < Food; i++)
            {
                SpawnFood();
            }
            Old = true;
        }
        else
        {
            for (int i = 0; i < Speed; i++)
            {
                if(RandomNumberList.GetNumber()==0)
                 SpawnFood();
            }
        }
    }

    public void SpawnFood()
    {
        if (this.transform.childCount < Food)
        {

            Vector3 SpawnPos;
            //SpawnPos = new Vector3(Random.Range(-WorldBorder.Me.Size * 2, WorldBorder.Me.Size * 2), Random.Range(-WorldBorder.Me.Size * 2, WorldBorder.Me.Size * 2), 0);


            SpawnPos = Random.insideUnitCircle * WorldBorder.Me.Size * 4;
            int i = 0;
            while (Vector2.Distance(new Vector2(0, 0), new Vector2(SpawnPos.x, SpawnPos.y)) > WorldBorder.Me.Size * 2.4 && i < 1000)
            {
                i++;
                SpawnPos = Random.insideUnitCircle * WorldBorder.Me.Size * 4;
            }
            if (i < 1000)
            {


                if (!Physics2D.OverlapCircle(SpawnPos, 1))
                    Instantiate(FoodP, SpawnPos, this.transform.rotation, this.transform);
            }
        }
    }
}
