using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    [Header("References")]
    private Dashing ds;
    public GameObject player;

    [Header("Health, damage and cd dash")]
    public int health = 200;
    public TextMeshProUGUI txt;

    public Transform spawn1, spawn2, spawn3, spawn4;

    private void Start()
    {
        //player = GameObject.FindWithTag("Player");
        ds = player.GetComponent<Dashing>();
        txt = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (ds.dashCdTimer > 0)
        {
            txt.text = "Cooldown: " + ds.dashCdTimer.ToString();
        }
        else
        {
            txt.text = "Cooldown: 0";
        }
        
    }

    public void LoseHealthSniper()
    {
        health = health - health;
        txt.text = "Health: " + health.ToString();

        if (health <= 0 && player.transform.position.z <= 285)
        {
            player.transform.position = spawn1.transform.position;
        }
        else if (health <= 0 && player.transform.position.z <= 578)
        {
            player.transform.position = spawn2.transform.position;
        }
        else if (health <= 0 && player.transform.position.z <= 859)
        {
            player.transform.position = spawn3.transform.position;
        }
        else if (health <= 0 && player.transform.position.z >= 860)
        {
            player.transform.position = spawn4.transform.position;
        }
    }
}
