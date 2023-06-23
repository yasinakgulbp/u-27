using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    private bool isMagnetActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            CoinCekimi[] coinCekimis = FindObjectsOfType<CoinCekimi>();
            foreach (CoinCekimi coinCekimi in coinCekimis)
            {
                coinCekimi.ActivateMagnet();
            }
        }
    }
}
