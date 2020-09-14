using UnityEngine;
using System.Collections;


namespace RPG
{

    public class EnemyArrow : MonoBehaviour
    {

        public float speed = 30f;
        public float life = 5f; // 5f is seconds apparently?
        public Character Char;
        public Animator anim;
        public Vector2 target;

        // Use this for initialization
        void Start()
        {

            if (GameObject.Find("Wall") != null)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.Find("Wall").GetComponent<Collider2D>());
            }
            Transform player = GameObject.Find("Player").GetComponent<Transform>();
            target.x = player.position.x;
            target.y = player.position.y;

            Rigidbody2D ArrowRigidBody = GetComponent<Rigidbody2D>();

            ArrowRigidBody.AddForce((target - new Vector2(transform.position.x, transform.position.y)) * speed);

            // Destroy(gameObject, 10f);

        }


        /*****************************************************************
         * We need the arrow to destroy itself upon impact with another collider 
         * 
         * This will also be the place where we do damage to the enemy it hits
         * 
         * ************************************************************/
        protected void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(this.gameObject);

            if (collision.gameObject.tag != "NPC")
            {
                collision.gameObject.SendMessage("TakeDamage", Char, SendMessageOptions.DontRequireReceiver);
            }
        }

        void OnDestroy()
        {
            Instantiate(Resources.Load("FireExplosion"), transform.position, Quaternion.identity);
        }

    }
}