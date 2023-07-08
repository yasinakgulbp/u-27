using UnityEngine;

public class BoxSpawn : MonoBehaviour
{
    public GameObject boxPrefab; // Ödül sandýðý prefabý
    public int boxCount; // Spawn edilecek sandýk sayýsý
    public float mapWidth; // Haritanýn geniþliði
    public float mapLength; // Haritanýn uzunluðu

    private void Start()
    {
        SpawnBoxes();
    }
    public void SpawnBoxes()
    {
        // Belirtilen sayýda sandýk spawn et
        for (int i = 0; i < boxCount; i++)
        {
            // Rastgele bir konum seç
            float spawnX = Random.Range(-mapWidth / 2f, mapWidth / 2f);
            float spawnZ = Random.Range(-mapLength / 2f, mapLength / 2f);
            Vector3 spawnPos = new Vector3(spawnX, 0f, spawnZ);

            // Sandýðý spawn et
            Instantiate(boxPrefab, spawnPos, Quaternion.identity);
        }
    }
}
