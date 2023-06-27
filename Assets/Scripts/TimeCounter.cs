using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public float startTime = 0f; // Sayacýn baþlama süresi
    public float counterSpeed = 1f; // Sayacýn hýzý

    private float currentTime = 0f;
    private TMP_Text counterText;

    private void Start()
    {
        counterText = GetComponent<TMP_Text>();
        currentTime = startTime;
    }

    private void Update()
    {
        currentTime += Time.deltaTime * counterSpeed;

        int minutes = Mathf.FloorToInt(currentTime / 60f); // Dakika hesaplama
        int seconds = Mathf.FloorToInt(currentTime % 60f); // Saniye hesaplama

        counterText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Sayacý TMP_Text'e yazdýrma
    }
}
