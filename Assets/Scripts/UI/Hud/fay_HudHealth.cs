using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace RPG
{

    public class fay_HudHealth : MonoBehaviour
    {

        public Character PlayerCharacter;
        // public int health;
        // public int PlayerCharacter.maxHealth;
        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;
        // Start is called before the first frame update


        void Start()
        {
            PlayerCharacter = GameObject.Find("Player").GetComponent<Character>();
            checkHealthAmount();
        }

        // Update is called once per frame
        void Update()
        {
            if (PlayerCharacter != null)
            {
                checkHealthAmount();
            }
        }


        void checkHealthAmount()
        {

            if (PlayerCharacter.currentHealth > PlayerCharacter.maxHealth)
            {
                PlayerCharacter.currentHealth = PlayerCharacter.maxHealth;
            }
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < PlayerCharacter.currentHealth)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }
                if (i < PlayerCharacter.maxHealth)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
        }

    }

}