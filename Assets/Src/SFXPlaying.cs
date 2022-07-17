using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
  public AudioSource laser;
  public AudioSource impact;
  public AudioSource teleport;

    public void playLaser() {
      if (laser.volume == 0f) {
        laser.volume = 1.0f;
      }

       laser.Play();
    }

    public void playImpact() {
      if (impact.volume == 0f) {
        impact.volume = 0.2f;
      }

       impact.Play();
    }

    public void playTeleport() {
      if (teleport.volume == 0f) {
        teleport.volume = 0.2f;
      }
       teleport.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
      impact.volume = 0f;
      teleport.volume = 0f;
      laser.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
