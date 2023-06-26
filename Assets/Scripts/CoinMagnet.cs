using UnityEngine;

public class CoinMagnet : MonoBehaviour
{
    private Transform player;
    private bool isMagnetEnabled = false;
    private float magnetForce = 0f; // Coin'lerin hareket hýzý
    public float magnetDuration = 5f; // Mýknatýs etkisinin süresi
    private float magnetTimer = 0f; // Mýknatýs etkisi süresini takip etmek için zamanlayýcý

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
        magnetTimer = 0f; // Mýknatýs etkisi baþladýðýnda zamanlayýcýyý sýfýrla
    }

    public void SetMagnetForce(float force)
    {
        magnetForce = force;
    }
}
