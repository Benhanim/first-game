using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    [Header("Health and Damage")]
    public int health = 200;
    public TextMeshProUGUI txt;

    private void Start()
    {
        txt = gameObject.GetComponent<TextMeshProUGUI>();
        txt.text = "Health: " + health.ToString();
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

    public void GainHealth()
    {
        health = health + 25;
        txt.text = "Health: " + health.ToString();
    }

    public void Test()
    {
        health = health - 100;
        txt.text = "Health: " + health.ToString();
    }
}
