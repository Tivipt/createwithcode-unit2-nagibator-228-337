using Unity.Burst.Intrinsics;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject[] animalKillers;
    private float spawnRangeX = 10f;  
    private float spawnRangeZ = 20f;  

    private float startDelay = 2f;
    private float startKillersDelay = 10f;

    private float spawnInterval = 1.5f;
    private float spawnKillersInterval = 6f;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomKiller", startKillersDelay, spawnKillersInterval);
    }

    void SpawnRandomAnimal()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);

        Vector3 spawnPos = new Vector3(randomX, 0, spawnRangeZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 180, 0));
    }

    void SpawnRandomKiller()
    {
        float randomZ = Random.Range(0, 15);
        float randomX = Random.Range(0, 2);
        int animalIndex = Random.Range(0, animalKillers.Length);
        Vector3 spawnPos = new Vector3 (0, 0, randomZ);

        if (randomX == 0){
            spawnPos.x = 15;
            Instantiate(animalKillers[animalIndex], spawnPos, Quaternion.Euler(0, -90, 0));
        }
        else if (randomX == 1){
            spawnPos.x = -15;
            Instantiate(animalKillers[animalIndex], spawnPos, Quaternion.Euler(0, 90, 0));
        }
    }
}
