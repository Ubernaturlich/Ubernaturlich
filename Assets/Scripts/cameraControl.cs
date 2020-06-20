using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    private float cameraSensitivity;
    private Vector2 mouseDirection;
    // Start is called before the first frame update
    void Start()
    {
        // Call relevant information from player script
        cameraSensitivity = this.gameObject.GetComponentInParent<Player>().verticalCameraSensitiviy;
    }

    // Update is called once per frame
    void Update()
    {
        // record the raw axis data to a vector 2 and convert the required axis to quaternion rotation
        Vector2 mouseChange = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));
        mouseDirection += mouseChange;
        this.transform.localRotation = Quaternion.AngleAxis(mouseDirection.y * cameraSensitivity, Vector3.right);
    }
}
