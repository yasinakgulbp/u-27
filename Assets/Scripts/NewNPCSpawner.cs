using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewNPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab; // Ödül sandýðý prefabý
    public List<Transform> spawnPoints = new List<Transform>();

    public void SpawnNPC(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                Instantiate(npcPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
