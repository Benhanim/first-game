using UnityEngine;

public class Finished : MonoBehaviour
{
    [Header("References")]
    private VictoryMenu vm;
    private GameObject cam;

    public bool touched;

    private void Start()
    {
        cam = GameObject.FindWithTag("MainCamera");
        vm = cam.GetComponent<VictoryMenu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            touched = true;
            vm.isVictory = true;
        }
    }
}
