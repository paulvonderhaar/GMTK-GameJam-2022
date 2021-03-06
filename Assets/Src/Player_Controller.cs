 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
        public float moveSpeed=5f;
        public InputAction playerControls;
        public Rigidbody2D rb;
        public Vector2 moveDirection = Vector2.zero;

        Vector2 mousePos;

        public Camera cam;

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
        mousePos=cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg-90f;
        rb.rotation = angle;


    }

    private void OnCollisionEnter2D(Collision2D collision) {

      if (collision.gameObject.tag == "Enemy") {
        // Game Over
        Destroy(gameObject);
        SceneManager.LoadScene(0);
      }

    }

}
