using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour
{
    private bool hasCollided = false; // Ýlk çarpýþma kontrolü için flag
    public float collisionCooldown = 1f; // Çarpýþma aralýðý için bekleme süresi

    private void OnTriggerEnter(Collider other)
    {
        if (!hasCollided && other.gameObject.CompareTag("Enemy"))
        {
            // Çarpýþma oldu ve Enemy'e 10 damage verildi
            other.gameObject.GetComponent<enemy6>().Damage(10);
            hasCollided = true; // Ýlk çarpýþma gerçekleþtiðinde flag'i true yap
            Invoke("ResetCollisionFlag2", 0.2f); // 1 saniye sonra ResetCollisionFlag metodunu çaðýr
            Invoke("ResetCollisionFlag", collisionCooldown); // 1 saniye sonra ResetCollisionFlag metodunu çaðýr
            
        }
    }

    private void ResetCollisionFlag()
    {   
        hasCollided = false; // hasCollided deðerini sýfýrla
        gameObject.SetActive(true);
    }
    private void ResetCollisionFlag2()
    {   
        gameObject.SetActive(false);
    }
}