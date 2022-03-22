using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{

    [SerializeField] public GameObject obj;
    float spawnTimer;
    public int spawnWaitTime = 10;
    public int x1 = -5;
    public int x2 = 1;
    public int y1 = -3;
    public int y2 = 2;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer >= spawnWaitTime) {
            SpawnObj();
            spawnTimer = 0;
        }
        else
        {
            spawnTimer += Time.deltaTime;
        }
    }

    void SpawnObj() {
        int x = Random.Range(x1, x2);
        int y = Random.Range(y1, y2);

         Vector2 spawnPos = new Vector2(x, y);
        float radius = 0.1f;
        
        if (Physics.CheckSphere (spawnPos, radius)) {
            return;
        } else {
            Instantiate(obj, new Vector2(x, y), Quaternion.identity);
        }
        
    }
}
