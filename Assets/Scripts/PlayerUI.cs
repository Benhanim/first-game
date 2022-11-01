using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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

    public void LoseHealth()
    {
        health = health - 25;
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
}
