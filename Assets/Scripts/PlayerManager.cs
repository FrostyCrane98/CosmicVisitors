using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    private GameObject actualPlayer;

    public void SpawnNewPlayer()
    {
        if (actualPlayer != null) 
        {
            Destroy(actualPlayer);
        }
        actualPlayer = Instantiate(PlayerPrefab);
    }
}
