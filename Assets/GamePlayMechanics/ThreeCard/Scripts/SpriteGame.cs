using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpriteGame
{
    public class SpriteGame : MonoBehaviour
    {

        public static SpriteGame instance;
        public List<Sprite> arr_spr_cards = new List<Sprite>();

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }else
            {
                DestroyImmediate(gameObject);
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}