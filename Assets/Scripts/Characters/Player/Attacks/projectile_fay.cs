using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{

    public class projectile_fay : MonoBehaviour
    {
        public Character Char;
        // bool canHurtPlayer = false;

        public bool isBouncy = false;
        int timesBounced = 0;
        public int bounceLimit = 2;
        public float speed = 50f;
        // public Transform player;
        public Vector2 target;
        Vector2 mousePosition;
        // Rigidbody2D ArrowRigidBody;
        public bool wsel = false;
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



        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (
                transform.position.x >= target.x - 5 && transform.position.x <= target.x + 5 &&
                transform.position.y >= target.y - 5 && transform.position.y <= target.y + 5 &&
                !wsel)
            {
                Destroy(GetComponent<Collider2D>());
                wsel = true;
                CircleCollider2D newCollider = gameObject.AddComponent<CircleCollider2D>();
                newCollider.radius = .5f;
                newCollider.offset = new Vector2(.3f, 0);
            }
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
            if (isBouncy)
            {
                timesBounced++;
                if (timesBounced >= bounceLimit)
                    Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
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