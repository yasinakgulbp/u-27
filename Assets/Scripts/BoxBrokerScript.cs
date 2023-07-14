using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBrokerScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PrizeBox"))
        {
            // Çarpýþma oldu ve Box'a 4 damage verildi
            other.gameObject.GetComponent<BoxBroke>().Damage(4);
        }
    }
}
