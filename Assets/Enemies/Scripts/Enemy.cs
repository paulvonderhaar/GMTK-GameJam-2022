using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform myPos;
    public Rigidbody2D rb;

    public float startHealth = 3f;
    public float hp;
    Vector2 moveDirection;
    Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        hp=startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector2(playerPos.position.x - myPos.position.x, playerPos.position.y - myPos.position.y).normalized;
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag == "Bullet") {
        hp -= 1;
        Debug.Log(hp);
        if(hp <= 0)
        {
          Destroy(gameObject);
        }


      }
    }
}
