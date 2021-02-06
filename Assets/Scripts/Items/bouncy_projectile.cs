using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class bouncy_projectile : MonoBehaviour
    {
        public Character Char;
        // bool canHurtPlayer = false;
        int timesBounced = 0;
        public int bounceLimit = 5;
        public float speed = 50f;
        // public Transform player;
        public Vector2 target;
        Vector2 mousePosition;

        // Use this for initialization
        void Start()
        {

            if (GameObject.Find("Wall") != null)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Wall").GetComponent<Collider2D>());
            }
            // ArrowRigidBody = GetComponent<Rigidbody2D>();
            // Animator PlayerAnim = GameObject.Find("Player").transform.GetChild(0).GetComponent<Animator>();
            Char = GameObject.Find("Player").GetComponent<Character>();


            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            target.x = worldPosition.x;
            target.y = worldPosition.y;


            Rigidbody2D ArrowRigidBody = GetComponent<Rigidbody2D>();

            ArrowRigidBody.AddForce((target - new Vector2(transform.position.x, transform.position.y)) * speed);
            Invoke("timedDestroy", 15);


        }

        protected void OnCollisionExit2D(Collision2D collision)
        {
            // if (collision.gameObject.tag == "Player")
            // {
            Destroy(GetComponent<Collider2D>());
            CircleCollider2D newCollider = gameObject.AddComponent<CircleCollider2D>();
            newCollider.radius = .5f;
            newCollider.offset = new Vector2(.3f, 0);
            // }
        }


        protected void OnCollisionEnter2D(Collision2D collision)
        {
            string explosionElement = "";
            string ele = gameObject.GetComponent<elements>().perk;

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
            }

            if (explosionElement != "")
                Instantiate(Resources.Load("ImpactExplosion/" + explosionElement), transform.position, Quaternion.identity);

            if (collision.gameObject.tag != "NPC")
            {
                collision.gameObject.SendMessage("TakeDamage", Char, SendMessageOptions.DontRequireReceiver);
            }
            if (collision.gameObject.GetComponent<getAffectedByElement>())
            {
                affectOther(collision.gameObject);
            }
            timesBounced++;
            Debug.Log(timesBounced);
            if (timesBounced >= bounceLimit)
                Destroy(this.gameObject);
        }
        void timedDestroy()
        {
            Destroy(this.gameObject);
        }

        void affectOther(GameObject TheAffected)
        {
            elements element = gameObject.GetComponent<elements>();
            if (element)
            {
                TheAffected.GetComponent<getAffectedByElement>().getAffected(element);
            }
        }


    }



}