using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy6 : MonoBehaviour
{
    public int Health = 10;
    public void Damage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}