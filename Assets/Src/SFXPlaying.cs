using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
  public AudioSource laser;
  public AudioSource impact;
  public AudioSource teleport;

  [SerializeField]
  private float _laserVolume;
  [SerializeField]
  private float _impactVolume;
  [SerializeField]
  private float _teleportVolume;

    public void playLaser() {
       laser.volume = _laserVolume;

       laser.Play();
    }

    public void playImpact() {
       impact.volume = _impactVolume;

       impact.Play();
    }

    public void playTeleport() {
       teleport.volume = _teleportVolume;
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
