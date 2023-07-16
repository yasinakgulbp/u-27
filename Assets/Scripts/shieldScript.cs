using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour
{
    private bool hasCollided = false; // �lk �arp��ma kontrol� i�in flag
    public float collisionCooldown = 4f; // �arp��ma aral��� i�in bekleme s�resi

    private void OnTriggerEnter(Collider other)
    {
        if (!hasCollided && other.gameObject.CompareTag("Enemy"))
        {
            // �arp��ma oldu ve Enemy'e 10 damage verildi
            other.gameObject.GetComponent<enemy6>().Damage(10);
            hasCollided = true; // �lk �arp��ma ger�ekle�ti�inde flag'i true yap
            Invoke("ResetCollisionFlag2", 0.1f); // 1 saniye sonra ResetCollisionFlag metodunu �a��r
            Invoke("ResetCollisionFlag", collisionCooldown); // 1 saniye sonra ResetCollisionFlag metodunu �a��r
            
        }
    }

    private void ResetCollisionFlag()
    {   
        hasCollided = false; // hasCollided de�erini s�f�rla
        gameObject.SetActive(true);
    }
    private void ResetCollisionFlag2()
    {   
        gameObject.SetActive(false);
    }
}