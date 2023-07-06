using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostRateScript : MonoBehaviour
{   
    public AutoAimShoot autoAimScript;
    // Start is called before the first frame update
    void Start()
    {
        autoAimScript = GetComponent<AutoAimShoot>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BoostRate"))
        {
            autoAimScript.fireRate = 30f;
        }
    }
}
