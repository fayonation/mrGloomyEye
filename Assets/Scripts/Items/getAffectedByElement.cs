using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class getAffectedByElement : MonoBehaviour
    {
        bool affected = false;
        float affectedSpriteAlpha = 0f;
        public string effect = "fr"; // fr, ic, sh, pl, bl
        public float effectDuration = 2;
        Animator anim;
        Rigidbody2D rb;


        public void getAffected(elements element = null)
        {
            if (effect == element.perk)
            {
                rb = transform.GetComponent<Rigidbody2D>();
                anim = transform.GetChild(0).GetComponent<Animator>();
                affected = true;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                anim.SetBool("affected", affected);
                Invoke("effectWearOff", effectDuration);
            }

        }

        void effectWearOff()
        {
            affected = false;
            anim.SetBool("affected", affected);
            Invoke("unfreeze", 1f);

        }

        void unfreeze()
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

}
