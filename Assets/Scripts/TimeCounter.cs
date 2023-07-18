using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    public float startTime = 0f;        // Sayac�n ba�lama s�resi
    public float counterSpeed = 1f;     // Sayac�n h�z�
    public AudioClip BoxSpawnSound;

    private float currentTime = 0f;
    private TMP_Text counterText;
    public BoxSpawn boxSpawnScript;     // BoxSpawn script referans�
    public NewNPCSpawner NewNpcSpawnScript, NewNpcSpawnScript2, NewNpcSpawnScript3, NewNpcSpawnScript4; // NPCSpawner script referans�

    private bool everyTenSeconds = true;
    private bool everyMinute = true;
    private bool everyTwentySeconds = true;

    private void Start()
    {
        counterText = GetComponent<TMP_Text>();
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime += Time.deltaTime * counterSpeed;

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        counterText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        if (minutes > 0 && minutes % 2 == 0 && seconds==0 && everyMinute)
        {
            AudioSource.PlayClipAtPoint(BoxSpawnSound, transform.position);
            boxSpawnScript.SpawnBoxes();        // Her dakika ba��nda yap�lacak i�lemler
            everyMinute = false;                // De�i�keni e�itle
            Invoke("ResetEveryMinute", 2f);     // 2 saniye sonra SetVariable metodu �a�r�lacak
        }
        if (seconds % 10 == 0 && everyTenSeconds)
        {
            NewNpcSpawnScript.SpawnNPC(1);       // Her 10 saniyede yap�lacak i�lemler
            NewNpcSpawnScript2.SpawnNPC(2);      // Her 10 saniyede yap�lacak i�lemler
            NewNpcSpawnScript4.SpawnNPC(1);      // Her 10 saniyede yap�lacak i�lemler
            //NewNpcSpawnScript2.SpawnNPC();      // Her 10 saniyede yap�lacak i�lemler
            //NewNpcSpawnScript3.SpawnNPC();      // Her 10 saniyede yap�lacak i�lemler
            everyTenSeconds = false;            // De�i�keni e�itle
            Invoke("ResetEveryTenSeconds", 2f); // 2 saniye sonra SetVariable metodu �a�r�lacak
        }
        if (seconds % 20 == 0 && everyTwentySeconds)
        {
            NewNpcSpawnScript3.SpawnNPC(1);      // Her 10 saniyede yap�lacak i�lemler
            NewNpcSpawnScript2.SpawnNPC(1);      // Her 10 saniyede yap�lacak i�lemler
            //NewNpcSpawnScript2.SpawnNPC();      // Her 10 saniyede yap�lacak i�lemler
            //NewNpcSpawnScript3.SpawnNPC();      // Her 10 saniyede yap�lacak i�lemler
            everyTwentySeconds = false;            // De�i�keni e�itle
            Invoke("ResetEveryTwentySeconds", 2f); // 2 saniye sonra SetVariable metodu �a�r�lacak
        }

        if (minutes >= 15)
        {
            PlayerPrefs.SetInt("levelend", 1);
            string targetSceneName = "MainMenuScene";
            SceneManager.LoadScene(targetSceneName);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

    }
    
    private void ResetEveryMinute()
    {
        everyMinute = true;     // De�i�keni e�itle
    }
    private void ResetEveryTenSeconds()
    {
        everyTenSeconds = true; // De�i�keni e�itle
    }
    private void ResetEveryTwentySeconds()
    {
        everyTwentySeconds = true; // De�i�keni e�itle
    }
}
