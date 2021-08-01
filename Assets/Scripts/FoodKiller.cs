using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodKiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="FoodP")
        {
            Destroy(collision.gameObject);
        }
    }
}
