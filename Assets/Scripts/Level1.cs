using UnityEngine;

public class Level1 : MonoBehaviour
{
    public Transform spawn;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = spawn.transform.position;
    }
}
