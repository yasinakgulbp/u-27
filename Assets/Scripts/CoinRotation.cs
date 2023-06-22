using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotationSpeed = 1f; // Dönme hýzý

    void Update()
    {
        transform.Rotate(0f, rotationSpeed, 0f); // Y ekseninde dönme   --Burasý animasyon þeklinde yapýlmaya çalýþýlacak--
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Oyuncuya çarpýþma kontrolü
        {
            Destroy(gameObject); // Coin nesnesini yok et
        }
    }
}