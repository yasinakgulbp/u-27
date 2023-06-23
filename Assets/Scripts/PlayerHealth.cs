using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Maksimum can deðeri
    public float currentHealth; // Mevcut can deðeri

    public Slider healthSlider; // Caný göstermek için Slider

    private bool isDead = false; // Ölüp ölmediðini kontrol etmek için bir bayrak

    private void Start()
    {
        currentHealth = maxHealth; // Baþlangýçta caný maksimum deðere ayarla
        healthSlider.maxValue = maxHealth; // Slider'ýn maksimum deðerini ayarla
        healthSlider.value = currentHealth; // Slider'ýn mevcut deðerini ayarla
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isDead) // Eðer düþmanla temas olduysa ve ölmediyse
        {
            TakeDamage(10f); // Caný azaltan fonksiyonu çaðýr, parametre olarak alýnan deðer düþmanýn verdiði zarardýr (örneðin 10)
        }
    }

    private void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; // Caný azalt
        healthSlider.value = currentHealth; // Slider'ýn mevcut deðerini güncelle

        if (currentHealth <= 0f)
        {
            Die(); // Eðer can sýfýra düþtüyse Die fonksiyonunu çaðýr (oyuncu ölür)
        }
    }

    private void Die()
    {
        isDead = true; // Oyuncu öldüðünde bayraðý true yap

        Debug.Log("Oyuncu öldü!"); // Konsola ölüm mesajýný yazdýr

        // Oyuncunun ölümüyle ilgili iþlemleri burada gerçekleþtirin
        // Örneðin, oyunu yeniden baþlatmak veya oyunu sonlandýrmak gibi
    }
}