using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public string type;

    // Start is called before the first frame update
    void Start()
    {
        string objName = GetComponent<SpriteRenderer>().name;
        Debug.Log(objName);
        if (objName == "lego") {
            type = "debuff";
        } else if (objName == "soda") {
            type = "buff";
        }
    }
}