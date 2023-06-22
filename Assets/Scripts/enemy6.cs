using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy6 : MonoBehaviour
{
    public int Health = 10;
    public GameObject coinPrefab;

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
        GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        coin.SetActive(true);
    }
}