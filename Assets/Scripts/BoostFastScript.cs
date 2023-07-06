using UnityEngine;
using KinematicCharacterController.Examples;
using System;

public class Controller : MonoBehaviour
{
    public ExampleCharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<ExampleCharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BoostFast"))
        {
            Debug.Log("Þu an çarpýþma oldu ve hýz arttýrýldý");
            characterController.MaxStableMoveSpeed = (int)Math.Round(characterController.MaxStableMoveSpeed * 1.1f);
        }

    }
}
