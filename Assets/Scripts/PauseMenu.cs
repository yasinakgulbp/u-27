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


        // Mouse imleci gösterilsin
        Cursor.visible = true;
        // Mouse yakalamasý kapatýlsýn
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

        // Mouse imleci kaybolmamasýný saðlayan kod
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
        {   Debug.Log(" if içerisindeyim çalýþmýþ olmasý gerekiyor ");
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
        // Sahneyi yeniden yükle
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
        UnityEditor.EditorApplication.isPlaying = false; //Bu kodu Build alacaðýmýz zaman sileceðiz. Yoksa çalýþmýyor. Fakat, þimdilik test ederken görebilmemiz için durmasý gerekiyor.
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
        // Ýstenilen sahnenin adý
        string targetSceneName = "MainMenuScene";
        // Sahneye dön
        SceneManager.LoadScene(targetSceneName);
    }

    public void UpgradeFast()
    {
        FastSound();
        Debug.Log("Hýz %10 arttýrýldý!");
        UpgradeSkillScript.FastUpgrade();
        UpgradeSkillAfter();
    }

    public void UpgradeJump()
    {
        JumpSound();
        Debug.Log("Zýplama Hýzý %10 Arttýrýldý!");
        UpgradeSkillScript.JumpUpgrade();
        UpgradeSkillAfter();
    }
    public void UpgradeDemage()
    {
        CharacterDamageSound();
        //Debug.Log("Demage arttýrýldý Arttýrýldý!");
        UpgradeSkillScript.DemageUpgrade();
        UpgradeSkillAfter();
    }
    public void UpgradeDroneDemage()
    {
        DroneDamageSound();
        //Debug.Log("Drone hasarýna +2 hasar eklendi pause menüden!");
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
        audioSource.clip = clickSound; // Ses dosyasýný atama
        audioSource.Play(); // Ses dosyasýný çal
    }

    public void FastSound()
    {
        audioSource.clip = fastSound; // Ses dosyasýný atama
        audioSource.Play(); // Ses dosyasýný çal
    }

    public void JumpSound()
    {
        audioSource.clip = jumpSound; // Ses dosyasýný atama
        audioSource.Play(); // Ses dosyasýný çal
    }

    public void HealthSound()
    {
        audioSource.clip = healthSound; // Ses dosyasýný atama
        audioSource.Play(); // Ses dosyasýný çal
    }

    public void DroneDamageSound()
    {
        audioSource.clip = droneDamageSound; // Ses dosyasýný atama
        audioSource.Play(); // Ses dosyasýný çal
    }

    public void CharacterDamageSound()
    {
        audioSource.clip = characterDamageSound; // Ses dosyasýný atama
        audioSource.Play(); // Ses dosyasýný çal
    }

    public void FireRateSound()
    {
        audioSource.clip = fireRateSound; // Ses dosyasýný atama
        audioSource.Play(); // Ses dosyasýný çal
    }
}