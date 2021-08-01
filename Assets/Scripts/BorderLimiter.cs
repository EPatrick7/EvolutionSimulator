using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderLimiter : MonoBehaviour
{
    private void Update()
    {
        if (WorldBorder.Me != null)
        {
            if (Vector2.Distance(new Vector2(0, 0), this.transform.position) > WorldBorder.Me.Size * 2.5)
            {

                Destroy(this.gameObject);
            }
        }
    }
}
