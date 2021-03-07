using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class distructable : MonoBehaviour
    {
        public int hits = 1;
        public float explosionScale = 1;
        string explosionElement = "";
        string objectEle = "";
        void Start()
        {
            objectEle = gameObject.GetComponent<elements>().perk;
            switch (objectEle)
            {
                case "ic":
                    explosionElement = "ImpactExplosion_ice";
                    break;
                case "fr":
                    explosionElement = "ImpactExplosion_fire";
                    break;
                case "er":
                    explosionElement = "ImpactExplosion_earth";
                    break;
                case "bc":
                    explosionElement = "ImpactExplosion_basic";
                    break;
                default:
                    explosionElement = "ImpactExplosion_basic";
                    break;
            }
        }
        void Update()
        {
            if (hits <= 0)
                Destroy(this.gameObject);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "bullet")
            {
                Debug.Log("hit");
                Destroy(col.gameObject);
                // if (objectEle != col.gameObject.GetComponent<elements>().perk)
                hits--;
                if (hits <= 0)
                    Destroy(this.gameObject);
            }
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "bullet")
            {
                Debug.Log("hit");
                Destroy(col.gameObject);
                Instantiate(Resources.Load("ImpactExplosion/" + explosionElement), transform.position, Quaternion.identity);
                hits--;
            }
        }

        void OnDestroy()
        {
            GameObject explosion = Instantiate(Resources.Load("ImpactExplosion/" + explosionElement), transform.position, Quaternion.identity) as GameObject;
            explosion.transform.localScale = new Vector3(explosionScale, explosionScale, explosionScale);
        }
    }
}