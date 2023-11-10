using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersSpawner : MonoBehaviour
{
    public static CharactersSpawner instance;

    [SerializeField] private GameObject[] catsList;
    [SerializeField] private GameObject[] thieves;
    [SerializeField] private Vector2 minSpawnPosition, maxSpawnPosition;
    [SerializeField] private int numberOfCats;
    [SerializeField] private int numberOfThieves;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnMobs();
        SpawnThieves();
    }

    private void SpawnMobs()
    {
        for (int i = 0; i < numberOfCats; i++)
        {
            float xPos = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
            float yPos = Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
            int cats = Random.Range(0, catsList.Length);
            Instantiate(catsList[cats], new Vector2( xPos, yPos), Quaternion.identity);
        }
    }

    private void SpawnThieves()
    {
        for (int i = 0; i < numberOfThieves; i++)
        {
            float xPos = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
            float yPos = Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
            int thief = Random.Range(0, thieves.Length);
            Instantiate(thieves[thief], new Vector2(xPos, yPos), Quaternion.identity);
        }
    }

    public void SpawnSingleThief()
    {
        float xPos = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
        float yPos = Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
        int thief = Random.Range(0, thieves.Length);
        Instantiate(thieves[thief], new Vector2(xPos, yPos), Quaternion.identity);
    }
}
