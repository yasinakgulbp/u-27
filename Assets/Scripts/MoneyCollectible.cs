using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCollectible : MonoBehaviour
{
    public static int MoneyCount = 0; // Toplanan coin sayýsý, tüm CoinCollectible objeleri arasýnda paylaþýlýr
    public TMP_Text MoneyCountText; // Coin sayýsý Text referansý

    // Start is called before the first frame update
    void Start()
    {
        MoneyCountText = GameObject.Find("MoneyCountText").GetComponent<TMP_Text>(); // Coin sayýsý Text referansýný bul
        UpdateMoneyCountText(); // Coin sayýsý Text'i güncelle
    }
    public void UpdateMoneyCountText()
    {
        MoneyCountText.text = "Money: " + MoneyCount.ToString(); // Coin sayýsý Text'i güncelle
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player karakteriyle çarpýþma kontrolü
        {
            MoneyCount += 750; // Coin sayýsýný bir artýr
            UpdateMoneyCountText(); // Coin sayýsý Text'i güncelle

            Destroy(gameObject); // MOney nesnesini yok et
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
