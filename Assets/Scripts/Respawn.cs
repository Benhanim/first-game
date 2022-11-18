using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform spawnPoint;
    public float minHeightForDeath;
    public GameObject player;

    void Update()
    {
        if (player.transform.position.y < minHeightForDeath)
        {
            player.transform.position = spawnPoint.position;
            Debug.Log("Te caiste del MAPA");
        }
    }
}
