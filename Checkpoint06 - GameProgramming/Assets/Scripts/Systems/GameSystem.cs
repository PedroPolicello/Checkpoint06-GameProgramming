using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] mobs;
    [SerializeField] private GameObject[] thieves;
    [SerializeField] private Vector2 minSpawnPosition, maxSpawnPosition;

    private void Start()
    {
        SpawnMobs();
        SpawnThieves();
    }

    private void SpawnMobs()
    {
        for (int i = 0; i < mobs.Length; i++)
        {
            float xPos = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
            float yPos = Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
            Instantiate(mobs[i], new Vector2( xPos, yPos), Quaternion.identity);
        }
    }

    private void SpawnThieves()
    {
        for (int i = 0; i < thieves.Length; i++)
        {
            float xPos = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
            float yPos = Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
            Instantiate(thieves[i], new Vector2(xPos, yPos), Quaternion.identity);
        }
    }
}
