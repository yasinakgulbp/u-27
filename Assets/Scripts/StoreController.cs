using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreController : MonoBehaviour
{
    public TMP_Text MoneyCount;
    public TMP_Text MoneyCount2;
    private int money;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SatýnAlim1()
    {
        money = PlayerPrefs.GetInt("money");
        money = money - 100;
        PlayerPrefs.SetInt("money", money);
        MoneyCount.text = PlayerPrefs.GetInt("money").ToString();
        MoneyCount2.text = PlayerPrefs.GetInt("money").ToString();
    }

    public void SatýnAlim2()
    {
        money = PlayerPrefs.GetInt("money");
        money = money - 200;
        PlayerPrefs.SetInt("money", money);
        MoneyCount.text = PlayerPrefs.GetInt("money").ToString();
        MoneyCount2.text = PlayerPrefs.GetInt("money").ToString();
    }

    public void SatýnAlim3()
    {
        money = PlayerPrefs.GetInt("money");
        money = money - 300;
        PlayerPrefs.SetInt("money", money);
        MoneyCount.text = PlayerPrefs.GetInt("money").ToString();
        MoneyCount2.text = PlayerPrefs.GetInt("money").ToString();
    }

    public void SatýnAlim4()
    {
        money = PlayerPrefs.GetInt("money");
        money = money - 400;
        PlayerPrefs.SetInt("money", money);
        MoneyCount.text = PlayerPrefs.GetInt("money").ToString();
        MoneyCount2.text = PlayerPrefs.GetInt("money").ToString();
    }

    public void SatýnAlim5()
    {
        money = PlayerPrefs.GetInt("money");
        money = money - 500;
        PlayerPrefs.SetInt("money", money);
        MoneyCount.text = PlayerPrefs.GetInt("money").ToString();
        MoneyCount2.text = PlayerPrefs.GetInt("money").ToString();
    }
}
