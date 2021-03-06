using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace shuffle
{
    public class CardManager : MonoBehaviour
    {
        public static CardManager instance;

        [SerializeField]
        private List<Sprite> cardSprites;
        [SerializeField]
        private GameObject cardHolder, cardPrefab, dummyCard, parentHolder;
        private int k, childCount;

        private CardView selectedCard, previousCard, nextCard;
        private GameObject dummyCardObj;

        public CardView SelectedCard { get => selectedCard; }

        // Start is called before the first frame update
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        private void Start()
        {
            for (int i = 0; i < 13; i++)
            {
                k = i;
                SpawnCard();
            }
        }

        public void SetSelectedCard(CardView card)
        {
            int selectedCardIndex = card.transform.GetSiblingIndex();
            selectedCard = card;
            selectedCard.childIndex = selectedCardIndex;
            selectedCard.transform.SetParent(parentHolder.transform);

            GetDummyCard().SetActive(true);
            GetDummyCard().transform.SetSiblingIndex(selectedCardIndex);

            childCount = cardHolder.transform.childCount;

            if(selectedCardIndex + 1 < childCount)
            {
                nextCard = cardHolder.transform.GetChild(selectedCardIndex + 1).GetComponent<CardView>();
            }
            if (selectedCardIndex - 1 >= 0)
            {
                previousCard = cardHolder.transform.GetChild(selectedCardIndex - 1).GetComponent<CardView>();
            }
        }

        public void MoveCard(Vector2 position)
        {
            if (selectedCard != null)
            {
                selectedCard.transform.position = position;
                CheckWithNextCard();
                CheckWithPreviousCard();
            }
        }

        public void ReleaseCard()
        {
            if (selectedCard != null)
            {
                GetDummyCard().SetActive(false);
                GetDummyCard().transform.SetParent(parentHolder.transform);

                selectedCard.transform.SetParent(cardHolder.transform);
                selectedCard.transform.SetSiblingIndex(selectedCard.childIndex);
                selectedCard = null;
            }
        }

        void CheckWithNextCard()
        {
            if (nextCard != null)
            {
                if (selectedCard.transform.position.x > nextCard.transform.position.x)
                {
                    int index = nextCard.transform.GetSiblingIndex();
                    nextCard.transform.SetSiblingIndex(dummyCardObj.transform.GetSiblingIndex());
                    dummyCardObj.transform.SetSiblingIndex(index);

                    previousCard = nextCard;

                    if(index + 1 < childCount)
                    {
                        nextCard = cardHolder.transform.GetChild(index + 1).GetComponent<CardView>();
                    }else
                    {
                        nextCard = null;
                    }
                }
            }
        }

        void CheckWithPreviousCard()
        {
            if (previousCard != null)
            {
                if (selectedCard.transform.position.x < previousCard.transform.position.x)
                {
                    int index = previousCard.transform.GetSiblingIndex();
                    previousCard.transform.SetSiblingIndex(dummyCardObj.transform.GetSiblingIndex());
                    dummyCardObj.transform.SetSiblingIndex(index);

                    nextCard = previousCard;

                    if (index - 1 >= 0)
                    {
                        nextCard = cardHolder.transform.GetChild(index - 1).GetComponent<CardView>();
                    }
                    else
                    {
                        previousCard = null;
                    }
                }
            }
        }

        void SpawnCard()
        {
            GameObject card = Instantiate(cardPrefab);
            card.name = "Card" + k;
            card.transform.SetParent(cardHolder.transform);
            card.GetComponent<CardView>().SetImg(cardSprites[k]);
        }

        GameObject GetDummyCard()
        {
            if (dummyCardObj != null)
            {
                if (dummyCardObj.transform.parent != cardHolder.transform)
                {
                    dummyCardObj.transform.SetParent(cardHolder.transform);
                }
                return dummyCardObj;
            }
            else
            {
                dummyCardObj = Instantiate(dummyCard);
                dummyCardObj.name = "DummyCard";
                dummyCardObj.transform.SetParent(cardHolder.transform);
            }
            return dummyCardObj;
        }
    }
}
