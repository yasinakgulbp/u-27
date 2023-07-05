using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostFireRate : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<AutoAimShoot>().DoubleFireRate();
        Destroy(gameObject);
    }
}
