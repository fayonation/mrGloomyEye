using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diminishingFlames : MonoBehaviour
{
    private ParticleSystem ps;
    ParticleSystem.EmissionModule emissionModule;
    public float theDiminishingRate = 50;
    // Start is called before the first frame update
    void Start()
    {
        ps = transform.GetChild(0).GetComponent<ParticleSystem>();
        emissionModule = ps.emission;

    }

    void diminishFlames()
    {
        theDiminishingRate = theDiminishingRate - 1;
        emissionModule.rate = theDiminishingRate;
        if (theDiminishingRate <= 0)
            Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Invoke("diminishFlames", 1); // start diminishing after 5 seconds
    }
}
