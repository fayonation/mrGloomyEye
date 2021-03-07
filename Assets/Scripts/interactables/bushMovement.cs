using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG
{
    public class bushMovement : MonoBehaviour
    {
        private BoxCollider2D bc;
        private Animator anim;
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }


        void OnTriggerStay2D(Collider2D collider)
        {
            Animator other = collider.gameObject.transform.GetChild(0).GetComponent<Animator>();
            if (collider.gameObject.tag == "Player")
            {
                if (other.GetBool("isAttacking") || other.GetBool("isWalking") || other.GetBool("isFloatating"))
                    anim.SetTrigger("playerIsHere");
            }
        }
    }
}