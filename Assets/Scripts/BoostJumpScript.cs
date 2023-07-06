using UnityEngine;
using KinematicCharacterController.Examples;

public class BoostJumpScript : MonoBehaviour
{
    public ExampleCharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<ExampleCharacterController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BoostJump"))
        {
            Debug.Log("Þu an çarpýþma oldu ve zýplama hýz arttýrýldý");
            characterController.JumpUpSpeed = 20f;
        }
        
    }
}
