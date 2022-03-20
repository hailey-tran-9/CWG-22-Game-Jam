using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodDream : Dream
{
    // Start is called before the first frame update
    public override void Action() { 
        // TODO Change the child health before destroying the game object
        Destroy(gameObject);
    }
}