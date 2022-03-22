using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DreamSpawner : MonoBehaviour
{

    [SerializeField] public GameObject dreamPrefab;
    [SerializeField] public float timeBetweenWaves = 2f; 
    [SerializeField] public float spawnDelay = 0.5f; 
    public enum SpawnState {SPAWNING, WAITING, COUNTING, READY, OFF};
    public float waveCountdown;

    [SerializeField] public SpawnState state; 

    [SerializeField] public int numWaves;
    [SerializeField] public int currWaveSize;
    public int currWave;
    
    // Start is called before the first frame update
    void Start()
    {

        waveCountdown = timeBetweenWaves;
        state = SpawnState.READY;
        currWave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.OFF) {
            return;
        }
        if (state == SpawnState.WAITING) {
            WaveCompleted(); 
        }
    
        if (waveCountdown <= 0) {
            if (state != SpawnState.SPAWNING) {
                StartCoroutine(SpawnWave(currWaveSize));
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
            spawnDelay = Mathf.Max(spawnDelay);
            yield return new WaitForSeconds(spawnDelay);
        }

        state = SpawnState.WAITING;
        yield return new WaitForSeconds(timeBetweenWaves);
        yield break;
    }

    void WaveCompleted() {
        state = SpawnState.COUNTING; 
        waveCountdown = timeBetweenWaves;
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
        int z = 0;
        transform.position = new Vector3(x, y,z);
    }
    void SpawnDream() {
        Instantiate(dreamPrefab, transform.position, Quaternion.identity);
   }

}