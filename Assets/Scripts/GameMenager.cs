using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject pauseMenuUI;

    public static GameManager instance; // GameManager'ý tek bir örnekle sýnýrlamak için kullanýlan bir örnekleme

    public enum GameState { Start, Playing, Pause, GameOver } // Oyun durumu enum

    public GameState gameState; // Oyun durumu deðiþkeni

    private bool isPaused = false; // Oyunun duraklatýlma durumunu tutan deðiþken

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //InitializeGame();
        StartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                //Oyun baþlarken pause menüyü deaktif ediyoruz
                //pauseMenuUI.SetActive(false);
                ResumeGame();
            }
            else
            {
                //Oyun baþlarken pause menüyü aktif ediyoruz
                //pauseMenuUI.SetActive(true);
                PauseGame();
            }
                
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
        // Mouse imleci kaybolmamasýný saðlayan kod

        //if (isPaused || gameState == GameState.GameOver)
        //{
        //    Cursor.visible = true;
        //    Cursor.lockState = CursorLockMode.Confined;
        //}
        //else
        //{
        //    Cursor.visible = false;
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
    }
    
    private void InitializeGame()
    {
        //Oun baþlarken pause menüyü deaktif ediyoruz
        pauseMenuUI.SetActive(false);
        // Oyun baþlatýldýðýnda yapýlmasý gereken baþlangýç iþlemleri
        gameState = GameState.Start;
        Time.timeScale = 1f; // Oyun zamanýný normale döndür
        // Diðer gerekli baþlangýç iþlemleri
    }

    public void StartGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // Mouse imleci gösterilsin
        Cursor.visible = true;
        // Mouse yakalamasý kapatýlsýn
        Cursor.lockState = CursorLockMode.Confined;

        // Oyunu baþlatma iþlemleri
        gameState = GameState.Playing;
        // Diðer gerekli baþlatma iþlemleri
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        gameState = GameState.Pause;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        gameState = GameState.Playing;
    }

    public void Restart()
    {
        // Sahneyi yeniden yükle
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
 
        CoinCollectible.coinCount = 0;
        // Oyunu baþlatma iþlemleri

        StartGame();
        ResumeGame();
    }

    public void ReturnToMainMenu()
    {
        pauseMenuUI.SetActive(false);
        // Ýstenilen sahnenin adý
        string targetSceneName = "MainScene";
        // Sahneye dön
        SceneManager.LoadScene(targetSceneName);
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false; //Bu kodu Build alacaðýmýz zaman sileceðiz. Yoksa çalýþmýyor. Fakat, þimdilik test ederken görebilmemiz için durmasý gerekiyor.
        Application.Quit();
    }

    public void GameOver()
    {
        // Oyunu bitirme iþlemleri
        gameState = GameState.GameOver;
        // Diðer gerekli oyun bitirme iþlemleri
    }
}
