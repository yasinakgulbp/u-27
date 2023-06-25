using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CoinCollectible : MonoBehaviour
{
    public float sliderIncrement = 5f; // Slider'ýn ilerleyeceði deðer
    private static int coinCount = 0; // Toplanan coin sayýsý, tüm CoinCollectible objeleri arasýnda paylaþýlýr
    private Slider slider; // Slider referansý
    private TMP_Text levelText; // Level Text referansý
    private TMP_Text coinCountText; // Coin sayýsý Text referansý


    private void Start()
    {
        slider = FindObjectOfType<Slider>(); // Slider referansýný bul
        levelText = slider.GetComponentInChildren<TMP_Text>(); // Level Text referansýný bul
        coinCountText = GameObject.Find("CoinCountText").GetComponent<TMP_Text>(); // Coin sayýsý Text referansýný bul
        UpdateCoinCountText(); // Coin sayýsý Text'i güncelle
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player karakteriyle çarpýþma kontrolü
        {
            slider.value += sliderIncrement; // Slider'ý belirtilen deðer kadar ilerlet

            if (slider.value >= slider.maxValue) // Slider tamamen dolmuþsa
            {
                slider.value = 0; // Slider'ý sýfýrla
                UpdateLevelText(); // Level Text'i güncelle
            }

            coinCount++; // Coin sayýsýný bir artýr
            UpdateCoinCountText(); // Coin sayýsý Text'i güncelle

            Destroy(gameObject); // Coin nesnesini yok et
        }
    }

    private void UpdateLevelText()
    {
        int currentLevel = int.Parse(levelText.text); // Mevcut level deðerini al
        currentLevel++; // Level deðerini bir arttýr
        levelText.text = currentLevel.ToString(); // Level Text'i güncelle
    }

    private void UpdateCoinCountText()
    {
        coinCountText.text = "Coin: " + coinCount.ToString(); // Coin sayýsý Text'i güncelle
    }
}
