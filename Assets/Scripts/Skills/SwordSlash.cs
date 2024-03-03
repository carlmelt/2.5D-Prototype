using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

/*
    Dummy Script:
    This script is responsible for the sword slash effect. 
    It is supposed to attached to the sword slash prefab. 

*/

public class SwordSlash : MonoBehaviour
{
    // public ParticleSystem slashEffect;
    public VisualEffect slashEffect;
    private Rigidbody rb;

    private void Awake() {
        // slashEffect = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        slashEffect.Play();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.right * Time.deltaTime * 0.5f);
    }
}
