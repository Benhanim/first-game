using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPistol : MonoBehaviour
{
    public PlayerUI pUI;
    public GameObject player;
    private PlayerMovement pm;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        pm = player.GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        pUI = player.GetComponent<PlayerUI>();

        if (collision.gameObject.CompareTag("Player") && pm.dashing)
        {
            Destroy(gameObject);
            Debug.Log("Invicible while dashing");
        }
        else if (collision.gameObject.CompareTag("Player") && !pm.dashing)
        {
            Destroy(gameObject);
            pUI.LoseHealthSniper();
            Debug.Log("Get REKT");
        }
    }
}
