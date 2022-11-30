using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerCam : MonoBehaviour
{
    public float sens = 800f;
    public Slider slider;

    public Transform orientation;
    public Transform camHolder;

    float xRotation;
    float yRotation;

    private void Start()
    {
        sens = PlayerPrefs.GetFloat("currentSensitivity", 800);
        slider.value = sens / 10;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("currentSensitivity", sens);
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camHolder.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void AdjustSpeed ()
    {
        sens = slider.value * 10;
    }

    public void DoFov(float endValue)
    {
        Camera cam = gameObject.GetComponent<Camera>();
        cam.DOFieldOfView(endValue, 0.25f);
        /*GetComponent<cam>.DOFieldOfView(endValue, 0.25f);*/
    }

    public void DoTilt(float zTilt)
    {
        transform.DOLocalRotate(new Vector3(0, 0, zTilt), 0.25f);
    }
}
