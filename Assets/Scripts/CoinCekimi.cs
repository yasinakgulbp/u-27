using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCekimi : MonoBehaviour
{
    private bool isMagnetActive = false;
    private float magnetDuration = 5f; // Mýknatýsýn etkin olacaðý süre (saniye)
    private float magnetTimer = 0f;

    void Update()
    {
        if (isMagnetActive)
        {
            magnetTimer += Time.deltaTime;

            if (magnetTimer >= magnetDuration)
            {
                isMagnetActive = false;
                magnetTimer = 0f;
            }
        }
    }

    public void ActivateMagnet()
    {
        isMagnetActive = true;
    }

    public bool IsMagnetActive()
    {
        return isMagnetActive;
    }

    void OnTriggerStay(Collider other)
    {
        if (isMagnetActive && other.CompareTag("Coin"))
        {
            Vector3 direction = transform.position - other.transform.position;
            other.transform.position += direction.normalized * Time.deltaTime * 25f;
        }
    }
}
