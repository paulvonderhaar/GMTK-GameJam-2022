using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    //Kills bullet after 5 seconds
    public void  Start()
 {
     StartCoroutine(SelfDestruct());
 }


    IEnumerator SelfDestruct()
 {
     yield return new WaitForSeconds(5f);
     Destroy(gameObject);
 }
//Kills on collision with the enemy, potential for "penetration paramater"
     void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }

}
