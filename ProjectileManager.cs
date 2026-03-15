using UnityEngine;
using System.Collections.Generic;

public class ProjectileManager : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int poolSize = 10;
    private Queue<GameObject> projectilePool;

    void Start()
    {
        CreatePool();
    }

    void CreatePool()
    {
        projectilePool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.SetActive(false);
            projectilePool.Enqueue(projectile);
        }
    }

    public GameObject GetProjectile()
    {
        if (projectilePool.Count > 0)
        {
            GameObject projectile = projectilePool.Dequeue();
            projectile.SetActive(true);
            return projectile;
        }
        else
        {
            Debug.LogWarning("No available projectiles in pool");
            return null;
        }
    }

    public void ReturnProjectile(GameObject projectile)
    {
        projectile.SetActive(false);
        projectilePool.Enqueue(projectile);
    }
}