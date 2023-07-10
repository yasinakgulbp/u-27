using UnityEngine;
using System;

public class UpgradeDroneSkill : MonoBehaviour
{
    public AutoAimShootDrone autoAimDroneScript;

    private void Start()
    {
        autoAimDroneScript = GetComponent<AutoAimShootDrone>();
    }
    public void DroneDemageUpgrade()
    {
        //Debug.Log("Upgrade skill ekranýnda geldi ve DroneDemageUpgrade fonksiyonu içerisinde þu an");
        autoAimDroneScript.DroneDemageChange(); //Pause menüden çaðýrýlacak þekilde hazýr 
    }

}
