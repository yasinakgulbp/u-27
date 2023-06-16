using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAimShoot : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Fire;
    public GameObject HitPoint;

    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    private List<Transform> enemies;
    private Transform currentEnemy;

    void Start()
    {
        FindEnemies();

        if (enemies.Count > 0)
        {
            currentEnemy = FindClosestEnemy();
        }
    }

    void Update()
    {
        if (currentEnemy != null)
        {
            RotateFirePoint(currentEnemy);

            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
        else
        {
            FindNewEnemy();
        }
    }

    public void FindEnemies()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new List<Transform>();

        foreach (GameObject enemyObject in enemyObjects)
        {
            enemies.Add(enemyObject.transform);
        }
    }

    public Transform FindClosestEnemy()
    {
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Transform enemy in enemies)
        {
            if (enemy != null)
            {
                float distance = Vector3.Distance(transform.position, enemy.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

        return closestEnemy;
    }

    public void RotateFirePoint(Transform target)
    {
        Vector3 targetDirection = target.position - FirePoint.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        FirePoint.rotation = Quaternion.Lerp(FirePoint.rotation, targetRotation, Time.deltaTime * 5f);
    }

    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(FirePoint.position, FirePoint.TransformDirection(Vector3.forward), out hit, 100))
        {
            Debug.DrawRay(FirePoint.position, FirePoint.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            GameObject a = Instantiate(Fire, FirePoint.position, Quaternion.identity);
            GameObject b = Instantiate(HitPoint, hit.point, Quaternion.identity);

            Destroy(a, 1);
            Destroy(b, 1);

            enemy6 enemy = hit.transform.GetComponent<enemy6>();

            if (enemy != null)
            {
                enemy.Damage(2);
            }
        }
    }

    public void FindNewEnemy()
    {
        if (enemies.Count > 0)
        {
            currentEnemy = FindClosestEnemy();
        }
    }
}
