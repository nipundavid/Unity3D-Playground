using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpriteGame
{
    public class GameController : MonoBehaviour
    {
        public GameObject cards;
        public Transform tf_BoxCard;
        public Transform[] arr_Tf_Player, arr_Tf_AI;
        public List<GameObject> listCard = new List<GameObject>();
        // Start is called before the first frame update
        void Start()
        {
            InstanceCard();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void InstanceCard()
        {
            for (int i = 0; i < SpriteGame.instance.arr_spr_cards.Count; i++)
            {
                GameObject _card = Instantiate(cards, tf_BoxCard.position, Quaternion.identity);
                _card.transform.SetParent(tf_BoxCard, true);
                _card.GetComponent<UICards>().img_cards.sprite = SpriteGame.instance.arr_spr_cards[i];
                listCard.Add(_card);
            }
            StartCoroutine(SplitCards());
        }

        public IEnumerator SplitCards()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(0.5f);
                int rdPlayer = Random.Range(0, listCard.Count);

                listCard[rdPlayer].transform.SetParent(arr_Tf_Player[i], true);
                iTween.MoveTo(listCard[rdPlayer], iTween.Hash("position", arr_Tf_Player[i].position, "easeType", "Linear", "loopType", "none", "time", 0.4f));

                iTween.RotateBy(listCard[rdPlayer], iTween.Hash("y", .5f, "easeType", "Linear", "loopType", "none", "time", 0.4f));
                yield return new WaitForSeconds(0.15f);
                listCard[rdPlayer].GetComponent<UICards>().gob_FrontCard.SetActive(false);

                listCard.RemoveAt(rdPlayer);

                yield return new WaitForSeconds(0.5f);
                int rdAI = Random.Range(0, listCard.Count);
                listCard[rdAI].transform.SetParent(arr_Tf_AI[i], true);
                iTween.MoveTo(listCard[rdAI], iTween.Hash("position", arr_Tf_AI[i].position, "easeType", "Linear", "loopType", "none", "time", 0.4f));

                iTween.RotateBy(listCard[rdAI], iTween.Hash("y", .5f, "easeType", "Linear", "loopType", "none", "time", 0.4f));
                yield return new WaitForSeconds(0.15f);
                listCard[rdAI].GetComponent<UICards>().gob_FrontCard.SetActive(false);
                listCard.RemoveAt(rdAI);

            }
        }
    }
}
