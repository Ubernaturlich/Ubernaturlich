using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    private float speed;
    private float jumpHeight;
    Player player;
    private float cameraSensitivity;
    private Vector2 mouseDirection;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        // call in values from player script and other components
        player = this.GetComponent<Player>();
        rb = this.GetComponent<Rigidbody>();
        speed = player.movementSpeed;
        jumpHeight = player.jumpHeight;
        cameraSensitivity = player.horizontalCameraSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        // record the raw axis data to a vector 2 and convert the required axis to quaternion rotation
        Vector2 mouseChange = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));
        mouseDirection += mouseChange;
        this.transform.localRotation = Quaternion.AngleAxis(mouseDirection.x * cameraSensitivity, Vector3.up);

        if (Input.GetKey(KeyCode.W)) { this.transform.position += this.transform.forward * speed; };
        if (Input.GetKey(KeyCode.S)) { this.transform.position -= this.transform.forward * speed; };
        if (Input.GetKey(KeyCode.Space))
        {
            if (rb.velocity.y < 0.01)
            { 
                rb.AddForce(Vector3.up * jumpHeight);
            }
        }
    }
    
}
