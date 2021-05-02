using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource flame;
    public AudioSource shoot;
    public AudioSource hit;

    public AudioClip shootClip;
    public AudioClip hitClip;

    // SINGLETON
    private static AudioManager _Instance;
    public static AudioManager Instance { get => _Instance; }

    private void Awake()
    {
        // Singleton feature
        if (_Instance != null && _Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _Instance = this;
        }
    }

    public void flameOn()
    {
        flame.enabled = true;
    }

    public void flameOff()
    {
        flame.enabled = false;
    }

    public void HitSound()
    {
        hit.PlayOneShot(hitClip);
    }

    public void shootSound()
    {
        shoot.PlayOneShot(shootClip);
    }
}
