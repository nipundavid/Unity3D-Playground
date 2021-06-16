using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace shuffle
{
    public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            CardManager.instance.MoveCard(eventData.position);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(eventData.pointerCurrentRaycast.gameObject != null)
            {
                if(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>() != null)
                {
                    CardManager.instance.SetSelectedCard(eventData.pointerCurrentRaycast.gameObject.GetComponent<CardView>());
                }
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            CardManager.instance.ReleaseCard();
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