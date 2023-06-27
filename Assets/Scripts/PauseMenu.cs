using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = true;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

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
         else
         {
             Cursor.visible = false;
             Cursor.lockState = CursorLockMode.Locked;
         }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
  
   public void Restart()
    {
        // Sahneyi yeniden yükle
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

         CoinCollectible.coinCount= 0;
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

    public void ReturnToMainMenu()
    {
        // Ýstenilen sahnenin adý
        string targetSceneName = "MainScene";
        // Sahneye dön
        SceneManager.LoadScene(targetSceneName);
    }
}
