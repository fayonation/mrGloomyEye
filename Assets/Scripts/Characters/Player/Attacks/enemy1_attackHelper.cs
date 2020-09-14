using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG
{
    public class enemy1_attackHelper : MonoBehaviour
    {

        public bool isRanged = false;
        EnemyDefaultAttackScript attackScript;
        void Start()
        {
            attackScript = transform.parent.GetComponent<EnemyDefaultAttackScript>();
        }
        public void helpMakeDamageBoxAppear()
        {
            if (!isRanged)
                attackScript.makeDamageBoxApper();
            else
                attackScript.makeArrowAppear();
        }
    }

}