using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
  public AudioSource laser;
  public AudioSource impact;

    public void playLaser() {
       laser.Play();
    }

    public void playImpact() {
       impact.Play();
    }


    // Start is called before the first frame update
    void Start()
    {
      impact.volume = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
