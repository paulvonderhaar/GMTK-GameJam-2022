using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public SFXPlaying sfx;

    public Transform myPos;
    public Rigidbody2D rb;
    public Dice dice;

    public int startHealth = 1;
    public int deathRoll = 1;
    public int hp;
    Vector2 moveDirection;
    Transform playerPos;
    bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        sfx = GameObject.FindWithTag("SFX").GetComponent<SFXPlaying>();
        playerPos = GameObject.FindWithTag("Player").transform;
        hp=startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector2(playerPos.position.x - myPos.position.x, playerPos.position.y - myPos.position.y).normalized;
    }

    void FixedUpdate() {
      if (isDead) { return; }
      rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    IEnumerator SelfDestruct(float delay)
 {
     yield return new WaitForSeconds(delay);
     Destroy(gameObject);
 }

 IEnumerator flyAway(float delay)
{
  yield return new WaitForSeconds(delay);
  Collider2D collider = gameObject.GetComponent<Collider2D>();
  collider.enabled = false;

  transform.position = new Vector3(myPos.position.x, myPos.position.y, -3f);

  rb.AddForce(moveDirection * -10f, ForceMode2D.Impulse);
  sfx.playTeleport();
}


    private void OnCollisionEnter2D(Collision2D collision) {
      if (isDead) { return; }

      if (collision.gameObject.tag == "Bullet") {
        sfx.playImpact();
        hp -= 1;
        if(hp <= 0)
        {
          int val = dice.Roll(null);
          Debug.Log(val);
          if (val == 1) {
            isDead = true;
            StartCoroutine(SelfDestruct(2f));
            StartCoroutine(flyAway(.3f));
            // Destroy(gameObject);
          }
          else {
            hp = startHealth;
          }
        }
      }
    }
}
