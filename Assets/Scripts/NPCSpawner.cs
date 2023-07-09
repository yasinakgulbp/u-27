using UnityEngine;
using System.Collections;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;
    public float spawnInterval = 3f;

    private void Start()
    {
        StartCoroutine(SpawnNPC());
    }

    public IEnumerator SpawnNPC()
    {
        while (true)
        {
            Instantiate(npcPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}