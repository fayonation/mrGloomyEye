using UnityEngine;
using System.Collections;

namespace RPG
{
    public abstract class AttackScript : MonoBehaviour
    {

        protected Animator Anim;
        public GameObject DamageBox;
        public Vector3 playerPos;
        public Vector3 adjustment;
        protected Enemy_Manager EnemyManagerScript;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public abstract void Attack();
        public abstract void makeDamageBoxApper();
        public abstract void makeArrowAppear();
    }

}
