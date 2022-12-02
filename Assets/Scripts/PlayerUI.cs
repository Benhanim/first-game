using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [Header("References")]
    private Dashing ds;
    public GameObject player;
    public Transform spawn1, spawn2, spawn3, spawn4;
    private PauseMenu pm;
    private VictoryMenu vm;
    public GameObject cam;
    public GameObject fObject;
    private Finished fs;

    [Header("Health, timer")]
    public int health = 200;
    public float timer, bestTime;
    public TextMeshProUGUI txt;
    public TextMeshProUGUI txt2;

    private void Start()
    {
        cam = GameObject.FindWithTag("MainCamera");
        pm = cam.GetComponent<PauseMenu>();
        vm = cam.GetComponent<VictoryMenu>();
        fObject = GameObject.FindWithTag("Finished");
        fs = fObject.GetComponent<Finished>();
        ds = player.GetComponent<Dashing>();
        txt = gameObject.GetComponent<TextMeshProUGUI>();
        txt2.text = timer.ToString();
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

        if (!pm.isPauseActive && !vm.isVictory)
        {
            timer += Time.deltaTime;
            bestTime = timer;
            txt2.text = "Time: " + timer.ToString("F2");
        }

        if (fs.touched)
        {
            PlayerPrefs.SetFloat("bestTime", bestTime);
            PlayerPrefs.Save();
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
