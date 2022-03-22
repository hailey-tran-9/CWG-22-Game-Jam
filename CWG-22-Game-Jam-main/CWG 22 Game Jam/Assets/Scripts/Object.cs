using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public string type;
    public Sprite buffSprite;
    public Sprite debuffSprite;

    // Start is called before the first frame update
    void Start()
    {
        float typeIndicator = Random.Range(0f, 10f);
        if (typeIndicator <= 5f) {
            type = "debuff";
            GetComponent<SpriteRenderer>().sprite = debuffSprite;
        } else {
            type = "buff";
            GetComponent<SpriteRenderer>().sprite = buffSprite;
        }
        Debug.Log(type + " spawned!");
    }
}