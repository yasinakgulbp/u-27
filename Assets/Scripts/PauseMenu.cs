using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
//using KinematicCharacterController.Examples;
//using System;

public class PauseMenu : MonoBehaviour
{
    //public ExampleCharacterController characterController;
    public UpgradeSkill UpgradeSkillScript;
    public shieldScript shieldScript;
    public UpgradeDroneSkill UpgradeDroneSkillScript;

    public Slider slider;
    public Slider HealtSlider;

    public GameObject safeZonePrefab;
    public bool SafeZoneIsActive = false;

    public GameObject pauseMenuUI;
    private bool isPaused = true;

    public GameObject upgradeMenu;
    private bool isPausedis = true;

    public AudioClip clickSound, fastSound, jumpSound, healthSound, characterDamageSound, droneDamageSound, fireRateSound;



    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        UpgradeSkillScript = FindObjectOfType<UpgradeSkill>();
        shieldScript = FindObjectOfType<shieldScript>();
        //characterController = GetComponent<ExampleCharacterController>();
        pauseMenuUI.SetActive(false);
        upgradeMenu.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;
        isPausedis = false;


        // Mouse imleci g�sterilsin
        Cursor.visible = true;
        // Mouse yakalamas� kapat�ls�n
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }

        // Mouse imleci kaybolmamas�n� sa�layan kod
        if (isPaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else if (isPausedis)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
    public void SliderIsFull()
    {
        if (slider.value >= slider.maxValue)
        {
            if (isPausedis)
                Resume1();
            else
                Pause1();
        }
    }

    public void UpgradeSafeZone() //BURAYA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        safeZonePrefab.SetActive(true);
        SafeZoneIsActive = true;
        if (SafeZoneIsActive)
        {   Debug.Log(" if i�erisindeyim �al��m�� olmas� gerekiyor ");
            shieldScript.degerArttir();
        }
        UpgradeSkillAfter();
    }


    public void Resume()
    {
        ClickSound();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Resume1()
    {
        ClickSound();
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPausedis = false;
    }

    public void Restart()
    {
        // Sahneyi yeniden y�kle
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

        CoinCollectible.coinCount = 0;
        Time.timeScale = 1f;
        isPaused = false;
        ClickSound();
    }

    public void Quit()
    {
        ClickSound();
        UnityEditor.EditorApplication.isPlaying = false; //Bu kodu Build alaca��m�z zaman silece�iz. Yoksa �al��m�yor. Fakat, �imdilik test ederken g�rebilmemiz i�in durmas� gerekiyor.
        Application.Quit();
    }

    private void Pause()
    {
        ClickSound();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void Pause1()
    {
        ClickSound();
        upgradeMenu.SetActive(true);
        Time.timeScale = 0f;
        isPausedis = true;
    }

    public void ReturnToMainMenu()
    {
        ClickSound();
        // �stenilen sahnenin ad�
        string targetSceneName = "MainMenuScene";
        // Sahneye d�n
        SceneManager.LoadScene(targetSceneName);
    }

    public void UpgradeFast()
    {
        FastSound();
        Debug.Log("H�z %10 artt�r�ld�!");
        UpgradeSkillScript.FastUpgrade();
        UpgradeSkillAfter();
    }

    public void UpgradeJump()
    {
        JumpSound();
        Debug.Log("Z�plama H�z� %10 Artt�r�ld�!");
        UpgradeSkillScript.JumpUpgrade();
        UpgradeSkillAfter();
    }
    public void UpgradeDemage()
    {
        CharacterDamageSound();
        //Debug.Log("Demage artt�r�ld� Artt�r�ld�!");
        UpgradeSkillScript.DemageUpgrade();
        UpgradeSkillAfter();
    }
    public void UpgradeDroneDemage()
    {
        DroneDamageSound();
        //Debug.Log("Drone hasar�na +2 hasar eklendi pause men�den!");
        UpgradeDroneSkillScript.DroneDemageUpgrade();
        UpgradeSkillAfter();
    }

    public void UpgradeSkillAfter()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPausedis = false;
    }

    public void UpgradeHealth()
    {
        HealthSound();
        if (HealtSlider.value <= 50f)
        {
            HealtSlider.value = HealtSlider.value + 25f;
        }
        else
        {
            HealtSlider.value = HealtSlider.value + (HealtSlider.value * 30 / 100);
        }
        Debug.Log("Al sana can geldi.");
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPausedis = false;
    }

    public void ClickSound()
    {
        audioSource.clip = clickSound; // Ses dosyas�n� atama
        audioSource.Play(); // Ses dosyas�n� �al
    }

    public void FastSound()
    {
        audioSource.clip = fastSound; // Ses dosyas�n� atama
        audioSource.Play(); // Ses dosyas�n� �al
    }

    public void JumpSound()
    {
        audioSource.clip = jumpSound; // Ses dosyas�n� atama
        audioSource.Play(); // Ses dosyas�n� �al
    }

    public void HealthSound()
    {
        audioSource.clip = healthSound; // Ses dosyas�n� atama
        audioSource.Play(); // Ses dosyas�n� �al
    }

    public void DroneDamageSound()
    {
        audioSource.clip = droneDamageSound; // Ses dosyas�n� atama
        audioSource.Play(); // Ses dosyas�n� �al
    }

    public void CharacterDamageSound()
    {
        audioSource.clip = characterDamageSound; // Ses dosyas�n� atama
        audioSource.Play(); // Ses dosyas�n� �al
    }

    public void FireRateSound()
    {
        audioSource.clip = fireRateSound; // Ses dosyas�n� atama
        audioSource.Play(); // Ses dosyas�n� �al
    }
}