using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dream : MonoBehaviour
{
    [SerializeField] private GameObject child;
    [SerializeField] public float speed = 1f;

    public virtual void Action() {
        return;
    }
    public virtual void SetUp() {
        return;
    }


    // Start is called before the first frame update
    void Start()
    {
        child = GameObject.FindGameObjectsWithTag("Child")[0];
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, child.transform.position, step);

        if (transform.position.x == child.transform.position.x && transform.position.y == child.transform.position.y) {
            Debug.Log("reached child");
            Action();
            child.GetComponent<Child>().ReduceHp();
        }
    }
}