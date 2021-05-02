using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Demon : MonoBehaviour
{
    public Animator anim;
   
    void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(Camera.main.transform.position - new Vector3(1,0,1));
    }

    public void Die()
    {
        GetComponent<NavMeshAgent>().isStopped = true;
        anim.SetTrigger("die");
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

        Invoke("Vanish", 2);
    }

    void Vanish()
    {
        Destroy(gameObject);
    }
}
