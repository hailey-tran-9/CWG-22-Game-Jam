using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dream : MonoBehaviour
{
    [SerializeField] private GameObject child;
    [SerializeField] private float speed;

    public virtual void Action() {
        return;
    }


    // Start is called before the first frame update
    void Start()
    {
        child = GameObject.FindGameObjectsWithTag("Child")[0];
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, child.transform.position, step);

        if (transform.position == child.transform.position) {
            Action();
        }
    }
}