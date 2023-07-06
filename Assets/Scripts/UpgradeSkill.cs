using UnityEngine;
using KinematicCharacterController.Examples;
using System;

public class UpgradeSkill : MonoBehaviour
{
    public ExampleCharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<ExampleCharacterController>();
    }

    public void FastUpgrade()
    {
        Debug.Log("Þu an çarpýþma oldu ve hýz arttýrýldý");
        characterController.MaxStableMoveSpeed = (int)Math.Round(characterController.MaxStableMoveSpeed * 1.1f);
    }

    public void JumpUpgrade()
    {
        characterController.JumpUpSpeed = (int)Math.Round(characterController.JumpUpSpeed * 1.1f);
    }
}
