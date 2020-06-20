using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    private float speedBase;
    private float speed;
    private float sprintMultiplier;
    private float jumpHeight;
    Player player;
    private float cameraSensitivity;
    private Vector2 mouseDirection;
    Rigidbody rb;
    NavMeshAgent Agent;
    BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        // call in values from player script and other components
        player = this.GetComponent<Player>();
        rb = this.GetComponent<Rigidbody>();
        collider = this.GetComponent<BoxCollider>();
        speedBase = player.movementSpeed;
        jumpHeight = player.jumpHeight;
        cameraSensitivity = player.horizontalCameraSensitivity;
        sprintMultiplier = player.sprintMultiplier;
        Agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // record the raw axis data to a vector 2 and convert the required axis to quaternion rotation
        Vector2 mouseChange = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));
        mouseDirection += mouseChange;
        this.transform.localRotation = Quaternion.AngleAxis(mouseDirection.x * cameraSensitivity, Vector3.up);
        if (Input.GetKey(KeyCode.LeftShift)) { speed = speedBase * sprintMultiplier; }
        else { speed = speedBase; }
        if (Input.GetKey(KeyCode.W)) { Agent.Move(this.transform.forward * speed); };
        if (Input.GetKey(KeyCode.S)) { Agent.Move(-this.transform.forward * speed); };
        if (Input.GetKey(KeyCode.Space))
        {
            if (rb.velocity.y < 0.01)
            { 
                rb.AddForce(Vector3.up * jumpHeight);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            collider.center = new Vector3(0, -0.25f, 0);
            collider.size = new Vector3(0, 0.5f, 0);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            collider.center = Vector3.zero;
            collider.size = Vector3.zero;
        }
        speed = speedBase;
    }
    
}
