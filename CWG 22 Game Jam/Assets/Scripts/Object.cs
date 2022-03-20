using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    Player _player;
    string _type;

    // Start is called before the first frame update
    void Start()
    {
        string objName = GetComponent<SpriteRenderer>().name;
        Debug.Log(objName);
        if (objName == "lego") {
            _type = "debuff";
        } else if (objName == "soda") {
            _type = "buff";
        }
        Debug.Log(_type);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Object methods
    private void OnTriggerEnter(Collider c) {
        // Applies the buff/debuff onto the player for 10 seconds
        // and removes the object from the game screen

        // Instantiate _player
        _player = c.collider.Player;

        // Apply buff/debuff
        if (_type == "buff") {
            StartCoroutine(SpeedUp());
        } else {
            StartCoroutine(Slow());
        }

        // Remove object
        Destroy(gameObject);
    }

    private IEnumerator Slow() {
        // Decreases the player speed
        _player.spd *= .75;
        yield return new WaitForSeconds(10f);
        _player.spd *= 1.25;
    }

    private IEnumerator SpeedUp() {
        // Increases the player speed
        _player.spd *= 1.25;
        yield return new WaitForSeconds(10f);
        _player.spd *= .75;
    }
}