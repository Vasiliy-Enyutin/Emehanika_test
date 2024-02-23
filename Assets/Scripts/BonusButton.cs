using System;
using Enums;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
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

        public event Action<BonusButton, BonusType, ResourceType, int> OnButtonClicked;

        private Button _button;

        private void Awake()
        {
	        _button = GetComponent<Button>();
	        _ownText.text = _cost.ToString();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
	        if (_button.interactable)
	        {
		        OnButtonClicked?.Invoke(this, _bonusType, _resourceType, _cost);
	        }
        }

        public void ChangeStateToMax()
        {
	        _ownText.text = "MAX";
	        _button.interactable = false;
        }
}