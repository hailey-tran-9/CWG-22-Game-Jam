using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamSpawner : MonoBehaviour
{

    [SerializeField] public GameObject dreamPrefab;
    public float timeBetweenWaves = 2f; 
    public float spawnDelay = 3f; 
    public enum SpawnState {SPAWNING, WAITING, COUNTING, READY, OFF};
    public float waveCountdown;

    [SerializeField] public SpawnState state; 
    [SerializeField] public int waveProgress;

    public int[] waves;
    public int nextWave = 0;

    private class Wave {
        public int size;
    }
    // Start is called before the first frame update
    void Start()
    {

        waveCountdown = timeBetweenWaves;
        state = SpawnState.READY;
        waveProgress = 0;
        waves = new int[] {3, 1, 2, 1,3, 2,1, 1, 2, 1};
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.OFF) {
            return;
        }
        if (state == SpawnState.WAITING) {
            Debug.Log(EnemiesAlive());
            if (EnemiesAlive() == false) {
                WaveCompleted();
            } else {
                return;
            }
        }
    
        if (waveCountdown <= 0) {
            if (state != SpawnState.SPAWNING) {
                StartCoroutine(SpawnWave(waves[nextWave]));
            } 
        }
        else {
            waveCountdown -= Time.deltaTime;
        }
    } 
    bool EnemiesAlive() {
        return GameObject.FindGameObjectsWithTag("Enemy").Length > 0;
    }

    IEnumerator SpawnWave(int size) {
        state = SpawnState.SPAWNING;
        for (int i = 0; i < size; i++) {
            SpawnDream();
        }

        state = SpawnState.WAITING;
        yield break;
    }


    void WaveCompleted() {
        state = SpawnState.COUNTING; 
        waveCountdown = timeBetweenWaves;
        if (nextWave + 1 >= waves.Length) {
            state = SpawnState.OFF;
            Debug.Log("turned off");
        }
        nextWave++;
    }

    void SpawnDream() {
        int x = Random.Range(-19, 4);
        int y = 0;
        if (x > -9) {
            int rand = Random.Range(0, 100);
            if (rand % 2 == 0) {
                y = -5;
            } else {
                y = 6;
            } 
        } 
        int z = (int) transform.position.z;
        Instantiate(dreamPrefab, new Vector3(x, y, z), Quaternion.identity);
 
   }

   IEnumerator ExecuteAfterTime(float time)
 {
     yield return new WaitForSeconds(time);

 }
}