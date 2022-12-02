using UnityEngine;
using TMPro;

public class VictoryMenu : MonoBehaviour
{
    [Header("Victory Screen")]
    public GameObject win;
    public bool isVictory;
    public TextMeshProUGUI txt;

    private void Update()
    {
        if (isVictory)
            VictoryScreen();
    }

    public void VictoryScreen()
    {
        win.SetActive(true);
        txt.text = "Best time: " + PlayerPrefs.GetFloat("bestTime").ToString("F2");
        this.GetComponent<PlayerCam>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
