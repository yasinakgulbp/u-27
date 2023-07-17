using UnityEngine;
using KinematicCharacterController.Examples;
using System;

public class BoostJumpScript : MonoBehaviour
{
    public ExampleCharacterController characterController;
    public PlayerHealth playerHealth;
    public GameObject jumpPrefab;
    public GameObject healthPrefab;
    public GameObject fastPrefab;


    public GameObject MagnetPrefab;
    private bool MagnetIsActive = true;

    public AudioClip soundJump, soundFast, soundHealth;

    private void Start()
    {
        characterController = GetComponent<ExampleCharacterController>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BoostJump"))
        {
            AudioSource.PlayClipAtPoint(soundJump, transform.position);
            Debug.Log("�arp��ma oldu ve z�plama h�z� art�r�ld�");
            characterController.JumpUpSpeed = Mathf.RoundToInt(characterController.JumpUpSpeed * 1.1f);
            PlayParticleEffect(jumpPrefab, other.transform.position);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("BoostFast"))
        {
            AudioSource.PlayClipAtPoint(soundFast, transform.position);
            Debug.Log("�arp��ma oldu ve hareket h�z� art�r�ld�");
            characterController.MaxStableMoveSpeed = Mathf.RoundToInt(characterController.MaxStableMoveSpeed * 1.1f);
            PlayParticleEffect(fastPrefab, other.transform.position);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("BoostHealth"))
        {
            AudioSource.PlayClipAtPoint(soundHealth, transform.position);
            Debug.Log("�arp��ma oldu ve sa�l�k art�r�ld�");
            playerHealth.healthSlider.value += 10f;
            PlayParticleEffect(healthPrefab, other.transform.position);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("MagnetCloser"))
        {
                Debug.Log("�arp��ma oldu ve MAGNET KAPATILDI------");
                MagnetPrefab.SetActive(false);
        }
        if (other.gameObject.CompareTag("MagnetOpener"))
        {
                Debug.Log("�arp��ma oldu ve MAGNET A�ILDI ++++++");
                MagnetPrefab.SetActive(true);
        }
    }


    private void PlayParticleEffect(GameObject particlePrefab, Vector3 position)
    {
        if (particlePrefab != null)
        {
            GameObject particleEffect = Instantiate(particlePrefab, position, Quaternion.identity);
            ParticleSystem particleSystem = particleEffect.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Play();
                Destroy(particleEffect, particleSystem.main.duration);
            }
            else
            {
                Destroy(particleEffect);
            }
        }
    }
}