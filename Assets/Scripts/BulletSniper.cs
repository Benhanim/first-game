using UnityEngine;

public class BulletSniper : MonoBehaviour
{
    public PlayerUI pUI;
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        player = collision.gameObject;
        pUI = player.GetComponent<PlayerUI>();

        if (collision.gameObject.CompareTag("Player"))
        {
            pUI.LoseHealthSniper();
            Destroy(gameObject);
            Debug.Log("Snipea2");
        }     
    }
}
