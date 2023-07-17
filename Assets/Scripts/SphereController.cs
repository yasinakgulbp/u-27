using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float coinMagnetForce = 30f; // Coin'lerin hareket hýzý

    private bool isSphereCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isSphereCollected = true;
            CollectCoins();
            Destroy(gameObject);
        }
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
}
