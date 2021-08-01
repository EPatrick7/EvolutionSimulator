using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Version : MonoBehaviour
{ 
    void Update()
    {
          this.GetComponent<TextMeshPro>().text = "" + Application.version;
    }
}
