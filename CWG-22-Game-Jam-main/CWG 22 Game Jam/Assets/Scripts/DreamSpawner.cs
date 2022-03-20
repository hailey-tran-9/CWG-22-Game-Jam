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

    [SerializeField] public int numWaves;
    public int currWave;
    
    // Start is called before the first frame update
    void Start()
    {

        waveCountdown = timeBetweenWaves;
        state = SpawnState.READY;
        currWave = 1;
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
                StartCoroutine(SpawnWave(currWave));
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
            RandomizePosition();
            spawnDelay = Mathf.Max(spawnDelay - currWave*0.1f, 1f);
            yield return new WaitForSeconds(spawnDelay);
        }

        state = SpawnState.WAITING;
        yield return new WaitForSeconds(timeBetweenWaves);
        yield break;
    }

    void ShuffleSpawnerPosition() {

    }
    void WaveCompleted() {
        state = SpawnState.COUNTING; 
        waveCountdown = timeBetweenWaves;
        if (currWave == numWaves) {
            state = SpawnState.OFF;
            Debug.Log("turned off");
        }
        currWave++;
    }

    void RandomizePosition() {
        int x = Random.Range(-11, 11);
        int y;
        if (x == -10 || x == 10) {
            y = Random.Range(-6, 6);
        } else {
            int rand = Random.Range(0, 100);
            if (rand % 2 == 0) {
                y = -5;
            } else {
                y = 6;
            } 
        }
        int z = (int) transform.position.z;
        transform.position = new Vector3(x, y,z);
    }
    void SpawnDream() {
        Instantiate(dreamPrefab, transform.position, Quaternion.identity);
   }

}