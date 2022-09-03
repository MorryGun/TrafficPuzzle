using System.Collections;
using UnityEngine;

[DefaultExecutionOrder(1000)]
public class CarSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    [SerializeField] GameManager gameManager;

    [SerializeField] float spawnTime = 1.0f;
    [SerializeField] float minSpawnTime = 2.0f;
    [SerializeField] float maxSpawnTime = 6.0f;

    public void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(spawnTime);

            var carIndex = Random.Range(0, cars.Length);
            Instantiate(cars[carIndex], transform.position, transform.rotation);

            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        };
    }
}
