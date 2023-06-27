using UnityEngine;

public class CoinDropper : MonoBehaviour
{
    public float spawnHeight = 1f;

    public void DropCoin(GameObject coinPrefab)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            Vector3 spawnPosition = hit.point + Vector3.up * spawnHeight;
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }
}


