using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kask : MonoBehaviour
{
    public GameObject kask1;
    public GameObject kaskmavi;
    public GameObject kaskmor;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("kask") == 1)
        {
            kask1.SetActive(false);
            kaskmor.SetActive(false);
            kaskmavi.SetActive(true);
        }
        if (PlayerPrefs.GetInt("kask") == 2)
        {
            kask1.SetActive(false);
            kaskmor.SetActive(true);
            kaskmavi.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
