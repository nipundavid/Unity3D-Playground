using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace shuffle
{
    public class CardView : MonoBehaviour
    {
        private Image img;
        public int childIndex;

        private void Awake()
        {
            img = GetComponent<Image>();
        }


        public void SetImg(Sprite cardSprite)
        {
            img.sprite = cardSprite;
        }
    }
}
