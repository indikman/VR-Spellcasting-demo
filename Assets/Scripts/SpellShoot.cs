using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SpellShoot : MonoBehaviour
{
    public VisualEffect fireParticle;
    public GameObject spellPrefab;
    public Transform referenceDirection;
    public Transform leftHand;

    private bool castCombination = false;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = false;
        fireParticle.Stop();
        castCombination = false;
    }

    void Update()
    {
        // FIRE PARTICLE
        if (Input.GetButton("XRI_Left_GripButton") && Input.GetButton("XRI_Left_TriggerButton"))
        {
            fireParticle.Play();
            castCombination = true;
            AudioManager.Instance.flameOn();
            line.enabled = true;
            line.SetPosition(0, leftHand.position);
            line.SetPosition(1, transform.position);
        }
        else
        {
            fireParticle.Stop();
            castCombination = false;
            AudioManager.Instance.flameOff();
            line.enabled = false;
        }


        // SHOOT SPELL
        if (Input.GetButtonDown("XRI_Right_TriggerButton") && castCombination)
        {
            GameObject spell = Instantiate(spellPrefab, transform.position, Quaternion.identity);
            spell.transform.rotation = referenceDirection.rotation;
            spell.GetComponent<SpellCast>().Shoot();
            AudioManager.Instance.shootSound();
        }
    }
}
