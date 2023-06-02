using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private List<GameObject> bulletsSpawned = new List<GameObject>();

    private void OnEnable()
    {
        EventManager.Instance.OnBulletShoot += OnBulletShoot;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnBulletShoot -= OnBulletShoot;
    }

    public void ClearBullets()
    {
        foreach (GameObject bullet in bulletsSpawned)
        {
            Destroy(bullet);
        }
        bulletsSpawned.Clear();
    }

    private void OnBulletShoot(GameObject bullet)
    {
        bulletsSpawned.Add(bullet);
    }
}
