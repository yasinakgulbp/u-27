using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeCounter : MonoBehaviour
{
    public float startTime = 0f;        // Sayacýn baþlama süresi
    public float counterSpeed = 1f;     // Sayacýn hýzý

    private float currentTime = 0f;
    private TMP_Text counterText;
    public BoxSpawn boxSpawnScript;     // BoxSpawn script referansý
    public NewNPCSpawner NewNpcSpawnScript, NewNpcSpawnScript2, NewNpcSpawnScript3; // NPCSpawner script referansý

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
            boxSpawnScript.SpawnBoxes();        // Her dakika baþýnda yapýlacak iþlemler
            everyMinute = false;                // Deðiþkeni eþitle
            Invoke("ResetEveryMinute", 2f);     // 2 saniye sonra SetVariable metodu çaðrýlacak
        }
        if (seconds % 10 == 0 && everyTenSeconds)
        {
            NewNpcSpawnScript.SpawnNPC(1);       // Her 10 saniyede yapýlacak iþlemler
            NewNpcSpawnScript2.SpawnNPC(1);      // Her 10 saniyede yapýlacak iþlemler
            //NewNpcSpawnScript2.SpawnNPC();      // Her 10 saniyede yapýlacak iþlemler
            //NewNpcSpawnScript3.SpawnNPC();      // Her 10 saniyede yapýlacak iþlemler
            everyTenSeconds = false;            // Deðiþkeni eþitle
            Invoke("ResetEveryTenSeconds", 2f); // 2 saniye sonra SetVariable metodu çaðrýlacak
        }
        if (seconds % 20 == 0 && everyTwentySeconds)
        {
            NewNpcSpawnScript3.SpawnNPC(1);      // Her 10 saniyede yapýlacak iþlemler
            //NewNpcSpawnScript2.SpawnNPC();      // Her 10 saniyede yapýlacak iþlemler
            //NewNpcSpawnScript3.SpawnNPC();      // Her 10 saniyede yapýlacak iþlemler
            everyTwentySeconds = false;            // Deðiþkeni eþitle
            Invoke("ResetEveryTwentySeconds", 2f); // 2 saniye sonra SetVariable metodu çaðrýlacak
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
        everyMinute = true;     // Deðiþkeni eþitle
    }
    private void ResetEveryTenSeconds()
    {
        everyTenSeconds = true; // Deðiþkeni eþitle
    }
    private void ResetEveryTwentySeconds()
    {
        everyTwentySeconds = true; // Deðiþkeni eþitle
    }
}
