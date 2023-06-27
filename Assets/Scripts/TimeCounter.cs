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
        counterText.text = currentTime.ToString("F2"); // Sayacý TMP_Text'e yazdýrma
    }
}
