using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBroke : MonoBehaviour
{
    public int Health = 10;
    public BoxRewardDropper BoxRewardDropper;
    public GameObject coinPrefab;

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
        BoxRewardDropper.DropCoin();
        Destroy(this.gameObject);
    }

}
