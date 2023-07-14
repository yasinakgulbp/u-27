using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBroke : MonoBehaviour
{
    public int Health = 2;
    public BoxRewardDropper BoxRewardDropper;
    public GameObject coinPrefab;
    public GameObject healthPrefab;
    public GameObject fastPrefab;
    public GameObject jumpPrefab;
    public GameObject magnetPrefab;

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
        BoxRewardDropper.DropCoin();
        Destroy(this.gameObject);
    }

}
