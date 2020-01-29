using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStarter : MonoBehaviour
{
    private int count = 1;
    [SerializeField]
    int setTime = 200;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(count);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject objectHit = other.gameObject;
        Debug.Log(objectHit.name);
    }

    private void OnTriggerStay(Collider other)
    {
        count++;
        if (count == setTime && other.gameObject.CompareTag("burnable"))
        {
            SetObjectOnFire(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        count = 0;
    }

    void SetObjectOnFire(GameObject obj)
    {
        Debug.Log("Burnable: " + obj.gameObject.name);

        Component[] fireParticles = obj.GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem fire in fireParticles)
        {
            fire.Play();
        }
    }

}
