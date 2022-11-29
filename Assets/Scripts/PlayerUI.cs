using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    [Header("References")]
    private Dashing ds;
    private GameObject player;

    [Header("Health, damage and cd dash")]
    public int health = 200;
    public TextMeshProUGUI txt;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
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

        if (health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void LoseHealthPistol()
    {
        health = health - 100;
        txt.text = "Health: " + health.ToString();

        if (health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
