using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float jumpHeight;
    public float verticalCameraSensitiviy;
    public float horizontalCameraSensitivity;
    public float sprintMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
