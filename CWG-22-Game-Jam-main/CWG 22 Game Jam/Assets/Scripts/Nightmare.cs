using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightmare : Dream
{
    // Start is called before the first frame update
    [SerializeField] public int damage;
    public override void SetUp() {
        speed = 2f;
    }
    public override void Action() {
        // TODO change the child health 
        Destroy(gameObject);
        child.GetComponent<Child>().ReduceHp();
    }
}