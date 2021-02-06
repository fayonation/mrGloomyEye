using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class torch : MonoBehaviour
    {
        public bool isLit = false;

        Collider2D collider;
        // Start is called before the first frame update
        void Start()
        {
            collider = GetComponent<Collider2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.GetComponent<elements>() != null)
            {
                string perk = coll.gameObject.GetComponent<elements>().perk;
                lightUp(perk);
            }
            Destroy(coll.gameObject);
        }
        void lightUp(string element)
        {
            GameObject flame = GetChildWithName(gameObject, element);
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            if (flame != null)
                flame.SetActive(true);
        }

        GameObject GetChildWithName(GameObject parentObj, string name)
        {
            Transform trans = parentObj.transform;
            Transform childTrans = trans.Find(name);
            if (childTrans != null)
            {
                return childTrans.gameObject;
            }
            else
            {
                return null;
            }
        }
    }
}