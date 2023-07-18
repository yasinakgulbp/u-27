using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kask : MonoBehaviour
{
    public GameObject kask1;
    public GameObject kaskmavi;
    public GameObject kaskmor;
    public GameObject casco;
    public GameObject kaskaltin;
    public GameObject kaskyesil;
    public GameObject kaskkirmizi;
    public GameObject cascosarimavi;
    public GameObject kaskmetalik;
    public GameObject fullbody;
    public GameObject fullbody1;
    public GameObject fullbody2;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("kask") == 1)
        {
            kask1.SetActive(false);
            kaskmor.SetActive(false);
            casco.SetActive(false);
            kaskmavi.SetActive(true);
            kaskaltin.SetActive(false);
            kaskyesil.SetActive(false);
            kaskkirmizi.SetActive(false);
            cascosarimavi.SetActive(false);
            kaskmetalik.SetActive(false);
            fullbody1.SetActive(false);
            fullbody2.SetActive(false);

        }
        if (PlayerPrefs.GetInt("kask") == 2)
        {
            kask1.SetActive(false);
            kaskmor.SetActive(true);
            casco.SetActive(false);
            kaskmavi.SetActive(false);
            kaskaltin.SetActive(false);
            kaskyesil.SetActive(false);
            kaskkirmizi.SetActive(false);
            cascosarimavi.SetActive(false);
            kaskmetalik.SetActive(false);
            fullbody1.SetActive(false);
            fullbody2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kask") == 3)
        {
            kask1.SetActive(false);
            kaskmor.SetActive(false);
            kaskmavi.SetActive(false);
            casco.SetActive(true);
            kaskaltin.SetActive(false);
            kaskyesil.SetActive(false);
            kaskkirmizi.SetActive(false);
            cascosarimavi.SetActive(false);
            kaskmetalik.SetActive(false);
            fullbody1.SetActive(false);
            fullbody2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kask") == 4)
        {
            kask1.SetActive(false);
            kaskmor.SetActive(false);
            kaskmavi.SetActive(false);
            casco.SetActive(false);
            kaskaltin.SetActive(true);
            kaskyesil.SetActive(false);
            kaskkirmizi.SetActive(false);
            cascosarimavi.SetActive(false);
            kaskmetalik.SetActive(false);
            fullbody1.SetActive(false);
            fullbody2.SetActive(false);
        }
        if (PlayerPrefs.GetInt("kask") == 5)
        {
            kask1.SetActive(false);
            kaskmor.SetActive(false);
            kaskmavi.SetActive(false);
            casco.SetActive(false);
            kaskaltin.SetActive(false);
            kaskyesil.SetActive(true);
            kaskkirmizi.SetActive(false);
            cascosarimavi.SetActive(false);
            kaskmetalik.SetActive(false);
            fullbody1.SetActive(false);
            fullbody2.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
