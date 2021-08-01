using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityLimit : MonoBehaviour
{
    public static int Limit = 100;
    public bool Dead;
    private void Start()
    {
        StartCoroutine(Delay());   
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.GetComponent<Rigidbody2D>());
        Destroy(this.GetComponent<BoxCollider2D>());
    }
    private void Update()
    {
        if(GameObject.FindObjectsOfType<EntityLimit>().Length>Limit)
        {
            if (GameObject.FindObjectsOfType<EntityLimit>()[0] != null)
                {
                if (!GameObject.FindObjectsOfType<EntityLimit>()[0].Dead)
                {
                    GameObject.FindObjectsOfType<EntityLimit>()[0].StopAllCoroutines();
                    Destroy((GameObject.FindObjectsOfType<EntityLimit>()[0].gameObject));
                }
                }
        }
    }
}
