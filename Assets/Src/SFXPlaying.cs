using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
  public AudioSource laser;
  public AudioSource impact;
  public AudioSource teleport;

    public void playLaser() {
       laser.Play();
    }

    public void playImpact() {
       impact.Play();
    }

    public void playTeleport() {
       teleport.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
      impact.volume = 0.2f;
      teleport.volume = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
