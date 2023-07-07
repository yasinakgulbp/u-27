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

    public Slider slider;
    public Slider HealtSlider;

    public GameObject pauseMenuUI;
    private bool isPaused = true;

    public GameObject upgradeMenu;
    private bool isPausedis = true;

    void Start()
    {
        UpgradeSkillScript = FindObjectOfType<UpgradeSkill>();
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
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Resume1()
    {
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
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false; //Bu kodu Build alacaðýmýz zaman sileceðiz. Yoksa çalýþmýyor. Fakat, þimdilik test ederken görebilmemiz için durmasý gerekiyor.
        Application.Quit();
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void Pause1()
    {
        upgradeMenu.SetActive(true);
        Time.timeScale = 0f;
        isPausedis = true;
    }

    public void ReturnToMainMenu()
    {
        // Ýstenilen sahnenin adý
        string targetSceneName = "MainScene";
        // Sahneye dön
        SceneManager.LoadScene(targetSceneName);
    }

    public void UpgradeFast()
    {
        Debug.Log("Hýz %10 arttýrýldý!");
        UpgradeSkillScript.FastUpgrade();
        UpgradeSkillAfter();
    }

    public void UpgradeJump()
    {
        Debug.Log("Zýplama Hýzý %10 Arttýrýldý!");
        UpgradeSkillScript.JumpUpgrade();
        UpgradeSkillAfter();
    }
    public void click3()
    {
        Debug.Log("Buton 3'e týklandý!");
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPausedis = false;
    }
    public void UpgradeSkillAfter()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPausedis = false;
    }

    public void UpgradeHealth()
    {
        if(HealtSlider.value <= 50f)
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
}