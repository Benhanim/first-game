using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPistol : MonoBehaviour
{
    public PlayerUI pUI;
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        player = collision.gameObject;
        pUI = player.GetComponent<PlayerUI>();

        if (collision.gameObject.CompareTag("Player"))
        {
            pUI.LoseHealthPistol();
            Destroy(gameObject);
        }
    }
}
