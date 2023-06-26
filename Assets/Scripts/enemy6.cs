using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy6 : MonoBehaviour
{
    public int Health = 10;
    public GameObject coinPrefab;
    public GameObject coinPrefab2;
    public GameObject coinPrefab3;

    public void Damage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            SpawnCoin();
            Destroy(this.gameObject);
        }
    }

    private void SpawnCoin()
    {
        GameObject coin = null;

        float randomValue = Random.value; // Rastgele bir deðer alýnýr (0 ile 1 arasýnda)

        if (randomValue < 0.5f) // %50 olasýlýk
        {
            coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
        else if (randomValue < 0.8f) // %30 olasýlýk
        {
            coin = Instantiate(coinPrefab2, transform.position, Quaternion.identity);
        }
        else // %20 olasýlýk
        {
            coin = Instantiate(coinPrefab3, transform.position, Quaternion.identity);
        }

        if (coin != null)
        {
            coin.SetActive(true);
        }
    }

}
