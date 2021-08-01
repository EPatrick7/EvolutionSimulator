using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chromosome : MonoBehaviour
{
    public static int MutationRate=25;

    public bool Bacteria;


    public float FoodCapacity;
    public float Size = 20;
    public float ReproductiveUrge;
    public float FoodEfficency;
    public float Speed;
    public float Health;
    public float Attack;
    public float SenseRange;


    public static int SpeciesAmount=2;

    public int SpeciesID;

    private void Start()
    {
        if (FoodCapacity < 2)
            FoodCapacity = 2;

        if (ReproductiveUrge < 2)
            ReproductiveUrge = 2;

        if (FoodEfficency < 1)
            FoodEfficency = 1;
        if (Speed < 0)
            Speed = 0;
        if (Health < 1)
            Health = 1;
        if (Attack < 0)
            Attack = 0;
        if (SenseRange < 4)
            SenseRange = 4;

        if (Size < 1)
            Size = 1;

    }

}
