using UnityEngine;
using System.Collections.Generic;
public class Car_Spawner1 : MonoBehaviour
{
    [SerializeField] private List<CAR> CARS = new List<CAR>();
    [SerializeField] private GameObject[] SpawnLoc;
    [SerializeField] private float[] TimeBetweenSpawns;

    [SerializeField] private GameObject selectedSpawnLoc;
    [SerializeField] private GameObject previousSpawnLoc;
    [SerializeField] private CAR NextCarToSpawn;
    [SerializeField] private float selectedTimeBetweenSpawn;
    [SerializeField] private float counter;
    [SerializeField] private Transform parent;


    [SerializeField] private int difficulty;

    private void Start()
    {
        previousSpawnLoc = SpawnLoc[0];
        difficulty = 1;
    }
    private void Update()
    {
        if (counter <= 0f)
        {
            InstantiateCar();
        }
        else
        {
            counter -= Time.deltaTime;
        }
    }
    private void Randomize()
    {
        selectedSpawnLoc = SpawnLoc[Random.Range(0, SpawnLoc.Length)];
        selectedTimeBetweenSpawn = TimeBetweenSpawns[Random.Range(0, TimeBetweenSpawns.Length)];
        NextCarToSpawn = CARS[Random.Range(0, CARS.Count)];

        while ((NextCarToSpawn.spawnAfterDifficulty > difficulty) || (previousSpawnLoc == selectedSpawnLoc))
        {
            Randomize();
        }

    }
    private void InstantiateCar()
    {
        Randomize();
        Instantiate(NextCarToSpawn.CarPrefab, selectedSpawnLoc.transform.position, Quaternion.identity, parent);
        counter = selectedTimeBetweenSpawn;

        difficulty++;
    }
}
[System.Serializable]
public class CAR 
{
    [SerializeField] public GameObject CarPrefab;
    [SerializeField] public int spawnAfterDifficulty;
}