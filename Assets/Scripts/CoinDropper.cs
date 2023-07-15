using UnityEngine;

public class CoinDropper : MonoBehaviour
{
    public float spawnHeightCoin = 1f;
    public float spawnHeightPoison = 0f;
    public float poisonDuration = 3f;

    public void DropCoin(GameObject coinPrefab)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            Vector3 spawnPosition = hit.point + Vector3.up * spawnHeightCoin;
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void DropPoison(GameObject poisonPrefab)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            Vector3 spawnPosition = hit.point + Vector3.up * spawnHeightPoison;
            GameObject poisonEffect = Instantiate(poisonPrefab, spawnPosition, Quaternion.identity);
            Destroy(poisonEffect, poisonDuration);
        }
    }
}


