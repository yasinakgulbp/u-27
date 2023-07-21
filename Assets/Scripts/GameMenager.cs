using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject pauseMenuUI;

    public static GameManager instance; // GameManager'� tek bir �rnekle s�n�rlamak i�in kullan�lan bir �rnekleme

    public enum GameState { Start, Playing, Pause, GameOver } // Oyun durumu enum

    public GameState gameState; // Oyun durumu de�i�keni

    private bool isPaused = false; // Oyunun duraklat�lma durumunu tutan de�i�ken

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
                //Oyun ba�larken pause men�y� deaktif ediyoruz
                //pauseMenuUI.SetActive(false);
                ResumeGame();
            }
            else
            {
                //Oyun ba�larken pause men�y� aktif ediyoruz
                //pauseMenuUI.SetActive(true);
                PauseGame();
            }
                
        }

        // Mouse imleci kaybolmamas�n� sa�layan kod
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
        // Mouse imleci kaybolmamas�n� sa�layan kod

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
        //Oun ba�larken pause men�y� deaktif ediyoruz
        pauseMenuUI.SetActive(false);
        // Oyun ba�lat�ld���nda yap�lmas� gereken ba�lang�� i�lemleri
        gameState = GameState.Start;
        Time.timeScale = 1f; // Oyun zaman�n� normale d�nd�r
        // Di�er gerekli ba�lang�� i�lemleri
    }

    public void StartGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // Mouse imleci g�sterilsin
        Cursor.visible = true;
        // Mouse yakalamas� kapat�ls�n
        Cursor.lockState = CursorLockMode.Confined;

        // Oyunu ba�latma i�lemleri
        gameState = GameState.Playing;
        // Di�er gerekli ba�latma i�lemleri
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
        // Sahneyi yeniden y�kle
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
 
        CoinCollectible.coinCount = 0;
        // Oyunu ba�latma i�lemleri

        StartGame();
        ResumeGame();
    }

    public void ReturnToMainMenu()
    {
        pauseMenuUI.SetActive(false);
        // �stenilen sahnenin ad�
        string targetSceneName = "MainScene";
        // Sahneye d�n
        SceneManager.LoadScene(targetSceneName);
    }

    public void Quit()
    {
        //UnityEditor.EditorApplication.isPlaying = false; //Bu kodu Build alaca��m�z zaman silece�iz. Yoksa �al��m�yor. Fakat, �imdilik test ederken g�rebilmemiz i�in durmas� gerekiyor.
        Application.Quit();
    }

    public void GameOver()
    {
        // Oyunu bitirme i�lemleri
        gameState = GameState.GameOver;
        // Di�er gerekli oyun bitirme i�lemleri
    }
}
