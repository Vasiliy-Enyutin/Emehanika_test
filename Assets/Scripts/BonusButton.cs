using System;
using Enums;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BonusButton : MonoBehaviour, IPointerClickHandler
{
        [SerializeField]
        private BonusType _bonusType;
        [SerializeField]
        private ResourceType _resourceType;
        [SerializeField]
        private int _cost;
        [SerializeField]
        private TextMeshProUGUI _ownText;

        public event Action<BonusType, ResourceType, int> OnButtonClicked;

        private void Awake()
        { 
	        _ownText.text = _cost.ToString();
        }

        public void OnPointerClick(PointerEventData eventData)
        { 
	        OnButtonClicked?.Invoke(_bonusType, _resourceType, _cost);
        }
}