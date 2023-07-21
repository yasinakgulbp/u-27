using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class levelController : MonoBehaviour
{
    private Scene _sahne;
    public TMP_Text MoneyCountText;
    public TMP_Text MoneyCountText2;

    public GameObject complated;
    public GameObject StoreUI;
    public GameObject LevelUI;

    public AudioClip buttonSound;
    private AudioSource audioSource;


    private void Awake()
    {
        //_sahne = GetComponent<Scene>();
        _sahne = SceneManager.GetActiveScene();
    }
    public void SonrakiSahne()
    {
        SceneManager.LoadScene(_sahne.buildIndex + 1);
        //PlayerPrefs.SetInt("ScoreCounts", score.instance.collectedPoint);
        ButtonSound();
    }

    public void ExitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false; //Bu kodu Build alacaðýmýz zaman sileceðiz. Yoksa çalýþmýyor. Fakat, þimdilik test ederken görebilmemiz için durmasý gerekiyor.
        Application.Quit();
        ButtonSound();
    }

    public void Start()
    {
        MoneyCountText.text = PlayerPrefs.GetInt("money").ToString();
        MoneyCountText2.text = PlayerPrefs.GetInt("money").ToString();

        audioSource = GetComponent<AudioSource>();

        //PlayerPrefs.DeleteKey("levelend");  //Süremizi sýfýrlamak için burayý ekledim.
        if (PlayerPrefs.GetInt("levelend") == 1)
        {
            complated.SetActive(true);
        }

        StoreUI.SetActive(false);
        LevelUI.SetActive(false);
    }

    public void StoreButton()
    {
        StoreUI.SetActive(true);
        ButtonSound();

    }

    public void LevelButton()
    {
        LevelUI.SetActive(true);
        ButtonSound();

    }

    public void BackButton()
    {
        LevelUI.SetActive(false);
        StoreUI.SetActive(false);
        ButtonSound();
    }

    public void ButtonSound()
    {
        audioSource.clip = buttonSound; // Ses dosyasýný atama
        audioSource.Play(); // Ses dosyasýný çal
    }
}