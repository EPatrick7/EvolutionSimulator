using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBorder : MonoBehaviour
{
    public float Size;
    public static WorldBorder Me;

    private void Start()
    {
        Me = this.GetComponent<WorldBorder>();
    }

    public void UpdatePos()
    {
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(Size, Size, this.transform.position.z), 0.1f);
        if (Size < 0.1f)
            Size = 0.1f;
    }

    private void OnDrawGizmosSelected()
    {
        UpdatePos();
    }
    void Update()
    {
        UpdatePos();
    }
}
