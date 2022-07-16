using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
        public float moveSpeed=5f;
        public InputAction playerControls;
        public Rigidbody2D rb;
        public Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {

        playerControls.Enable();
    }
    private void onDisable()
    {   Debug.Log("Disabeled");
        playerControls.Disable();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>().normalized;

    }

    void FixedUpdate() {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

}
