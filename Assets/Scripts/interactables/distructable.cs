using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class distructable : MonoBehaviour
    {
        private int hits = 1;
        string explosionElement = "";
        void Start()
        {
            string ele = gameObject.GetComponent<elements>().perk;
            Debug.Log(ele);
            switch (ele)
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

        // Update is called once per frame
        void Update()
        {
            if (hits <= 0)
            {
                Instantiate(Resources.Load("ImpactExplosion/" + explosionElement), transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }

        // public void TakeDamage(Character Char)
        // {
        //     // Remove HP.
        //     currentHealth -= Char.damage;
        //     EnemyHitAudio.clip = TakeDamageSound;
        //     EnemyHitAudio.Play();

        //     if (currentHealth <= 0)
        //     {
        //         // Death sound effects have to come through player because we destroy the enemy too fast
        //         PlayerAudio.clip = DieSound;
        //         PlayerAudio.Play();

        //         Death();
        //         return;
        //     }

        //     //we dont die so we need the proper knockback
        //     StartCoroutine(Flasher());
        //     hit(Char.transform, Char.joltAmount);
        // }

        void OnTriggerEnter2D(Collider2D col)
        {
            // Animator other = col.gameObject.transform.GetChild(0).GetComponent<Animator>();
            if (col.gameObject.tag == "bullet")
            {
                Destroy(col.gameObject);
                hits--;
            }
        }
    }
}