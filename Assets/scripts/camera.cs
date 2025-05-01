using UnityEngine;

public class camera : MonoBehaviour
{
    private float x;
    private float y;
    public float sensitivity = 2f;
    private Vector3 rotate;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        //load sensitivity from PlayerPrefs
        sensitivity = PlayerPrefs.GetFloat("Sensitivity", 2f);
    }

    void Update()
    {

        if (Time.timeScale == 0f) return;
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");

        rotate = new Vector3(-x * sensitivity, y * sensitivity, 0);
        transform.eulerAngles += rotate;
    }
}

