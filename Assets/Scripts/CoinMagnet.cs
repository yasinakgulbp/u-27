using UnityEngine;

public class CoinMagnet : MonoBehaviour
{
    private Transform player;
    private bool isMagnetEnabled = false;
    private float magnetForce = 0f; // Coin'lerin hareket h�z�
    public float magnetDuration = 5f; // M�knat�s etkisinin s�resi
    private float magnetTimer = 0f; // M�knat�s etkisi s�resini takip etmek i�in zamanlay�c�
    public float coinMagnetForce = 30f; // Coin'lerin hareket h�z�

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player == null)
        {
            Destroy(gameObject);
            return;
        }

        if (isMagnetEnabled)
        {
            if (magnetTimer <= magnetDuration)
            {
                Vector3 direction = player.position - transform.position;
                transform.position += direction.normalized * magnetForce * Time.deltaTime;
                magnetTimer += Time.deltaTime;
            }
            else
            {
                isMagnetEnabled = false;
            }
        }
    }

    public void SetMagnetTarget()
    {
        isMagnetEnabled = true;
        magnetTimer = 0f; // M�knat�s etkisi ba�lad���nda zamanlay�c�y� s�f�rla
    }

    public void SetMagnetForce(float force)
    {
        magnetForce = force;
    }

    private void CollectCoins()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        foreach (GameObject coin in coins)
        {
            CoinMagnet coinMagnet = coin.GetComponent<CoinMagnet>();
            coinMagnet.SetMagnetTarget();
            coinMagnet.SetMagnetForce(coinMagnetForce);
        }
    }


    private void OnTriggerEnter(Collider sphereMagnet)
    {
        if (sphereMagnet.CompareTag("Coin"))
        {
            CoinMagnet coinMagnet = sphereMagnet.GetComponent<CoinMagnet>();
            coinMagnet.SetMagnetTarget();
            coinMagnet.SetMagnetForce(coinMagnetForce);
        }
    }
}
