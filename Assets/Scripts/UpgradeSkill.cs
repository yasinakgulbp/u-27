using UnityEngine;
using KinematicCharacterController.Examples;
using System;

public class UpgradeSkill : MonoBehaviour
{
    public ExampleCharacterController characterController;
    public AutoAimShoot autoAimScript;

    private void Start()
    {
        characterController = GetComponent<ExampleCharacterController>();
        autoAimScript = GetComponent<AutoAimShoot>();
    }

    public void FastUpgrade()
    {
        Debug.Log("Þu an çarpýþma oldu ve hýz arttýrýldý");
        characterController.MaxStableMoveSpeed = (int)Math.Round(characterController.MaxStableMoveSpeed * 1.1f);
    }
    public void DemageUpgrade()
    {
        autoAimScript.DemageChange(); //Pause menüden çaðýrýlacak þekilde hazýr
    }

    public void JumpUpgrade()
    {
        characterController.JumpUpSpeed = (int)Math.Round(characterController.JumpUpSpeed * 1.1f);
    }
}
