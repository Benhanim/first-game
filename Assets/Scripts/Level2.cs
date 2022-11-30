using UnityEngine;

public class Level2 : MonoBehaviour
{
    public Transform spawn;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = spawn.transform.position;
    }
}
