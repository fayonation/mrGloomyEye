using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class dropRandom : MonoBehaviour
    {
        void OnDestroy()
        {
            float chance = Random.Range(0, 100);
            Debug.Log(chance);
            if (chance < 10)
                GameObject.Instantiate(Resources.Load("Heart"), new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            if (chance >= 10 && chance < 50)
                GameObject.Instantiate(Resources.Load("Rupee"), new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }
}