using System;
using System.Collections.Generic;
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
        private List<int> _costs;
        [SerializeField]
        private TextMeshProUGUI _ownText;

        private int _currentCostStage = 0;

        public event Action<BonusButton, BonusType, ResourceType, int> OnButtonClicked;

        private Button _button;

        private void Awake()
        {
	        _button = GetComponent<Button>();
	        _ownText.text = _costs[_currentCostStage].ToString();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
	        if (_button.interactable)
	        {
		        OnButtonClicked?.Invoke(this, _bonusType, _resourceType, _costs[_currentCostStage]);
	        }
        }

        public void ChangeCostStage()
        {
	        _currentCostStage++;
	        if (_currentCostStage < _costs.Count)
	        {
		        _ownText.text = _costs[_currentCostStage].ToString();
	        }
	        else
	        {
		        DisableButton();
	        }
        }

        public void DisableButton()
        {
	        _ownText.text = "MAX";
	        _button.interactable = false;
        }
}