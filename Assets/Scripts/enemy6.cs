using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy6 : MonoBehaviour
{
    public int Health = 10;
    public CoinDropper coinDropper;
    public GameObject coinPrefab;
    public AudioClip sound;

    public void Damage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
        coinDropper.DropCoin(coinPrefab);
        Destroy(this.gameObject);
    }
}