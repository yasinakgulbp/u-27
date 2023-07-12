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

    private void Start()
    {
        characterController = GetComponent<ExampleCharacterController>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BoostJump"))
        {
            Debug.Log("Çarpýþma oldu ve zýplama hýzý artýrýldý");
            characterController.JumpUpSpeed = Mathf.RoundToInt(characterController.JumpUpSpeed * 1.1f);
            PlayParticleEffect(jumpPrefab, other.transform.position);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("BoostFast"))
        {
            Debug.Log("Çarpýþma oldu ve hareket hýzý artýrýldý");
            characterController.MaxStableMoveSpeed = Mathf.RoundToInt(characterController.MaxStableMoveSpeed * 1.1f);
            PlayParticleEffect(fastPrefab, other.transform.position);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("BoostHealth"))
        {
            Debug.Log("Çarpýþma oldu ve saðlýk artýrýldý");
            playerHealth.healthSlider.value += 10f;
            PlayParticleEffect(healthPrefab, other.transform.position);
            Destroy(other.gameObject);
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