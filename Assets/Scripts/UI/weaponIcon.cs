using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG
{
    public class weaponIcon : MonoBehaviour
    {
        public Sprite[] weaponIcons;
        Image icon;
        // Start is called before the first frame update
        private void Start()
        {
            icon = GetComponent<Image>();
            icon.sprite = weaponIcons[0];
        }
        public void updateIcon(int current)
        {
            icon.sprite = weaponIcons[current];
        }
    }
}