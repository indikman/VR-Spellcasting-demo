using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    public float speed = 10f;
    public GameObject monsterHitParticle;
    public GameObject groundHitParticle;

    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("TimeOut", 5);
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        body.velocity = transform.forward * speed;
    }

    void TimeOut()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("monster"))
        {
            //Moster die!
            Instantiate(monsterHitParticle, transform.position, Quaternion.identity);
            other.GetComponent<Demon>().Die();
            GameManager.Instance.MonsterDied();
            AudioManager.Instance.HitSound();
            Destroy(gameObject);

        }
        else if (other.gameObject.CompareTag("ground"))
        {
            Instantiate(groundHitParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
