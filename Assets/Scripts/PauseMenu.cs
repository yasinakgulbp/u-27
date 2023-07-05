using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Slider slider;

    public GameObject pauseMenuUI;
    private bool isPaused = true;

    public GameObject upgradeMenu;
    private bool isPausedis = true;

    void Start()
    {
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

    public void click1()
    {
        Debug.Log("Buton 1'e týklandý!");
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPausedis = false;
    }

    public void click2()
    {
        Debug.Log("Buton 2'ye týklandý!");
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPausedis = false;
    }
    public void click3()
    {
        Debug.Log("Buton 3'e týklandý!");
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isPausedis = false;
    }
}