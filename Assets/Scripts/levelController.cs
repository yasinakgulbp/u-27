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

    public GameObject StoreUI;

    public GameObject LevelUI;


    private void Awake()
    {
        //_sahne = GetComponent<Scene>();
        _sahne = SceneManager.GetActiveScene();
    }
    public void SonrakiSahne()
    {
        SceneManager.LoadScene(_sahne.buildIndex + 1);
        //PlayerPrefs.SetInt("ScoreCounts", score.instance.collectedPoint);
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false; //Bu kodu Build alacaðýmýz zaman sileceðiz. Yoksa çalýþmýyor. Fakat, þimdilik test ederken görebilmemiz için durmasý gerekiyor.
        Application.Quit();
    }

    public void Start()
    {
        MoneyCountText.text = PlayerPrefs.GetInt("money").ToString();
        MoneyCountText2.text = PlayerPrefs.GetInt("money").ToString();

        StoreUI.SetActive(false);
        LevelUI.SetActive(false);
    }

    public void StoreButton()
    {
        StoreUI.SetActive(true);
    
    }

    public void LevelButton()
    {
        LevelUI.SetActive(true);
        
    }

    public void BackButton()
    {
        LevelUI.SetActive(false);
        StoreUI.SetActive(false);
    }

    public void LevelCheck()
    {
        //PlayerPrefs.DeleteKey("levelend");  //Süremizi sýfýrlamak için burayý ekledim.
        if (PlayerPrefs.GetInt("levelend") == 1)
        {
            Debug.Log("Bölüm 1 tamamlandý");
        }
    }
}
