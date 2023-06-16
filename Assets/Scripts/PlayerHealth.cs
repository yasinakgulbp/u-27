using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    float maxHealth = 100;

    public Slider healthSlider;

    public void Update()
    {
        healthSlider.value = Health;

        if (Input.GetKeyDown(KeyCode.H))
        {
            GetDamage(5);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            // NPC ile temas edildiðinde GetDamage fonksiyonunu çaðýr
            GetDamage(5);
        }
    }

    public void GetDamage(float amount)
    {
        Health -= amount;
    }
}
