using System;
using Enums;
using UnityEngine;

public class ButtonsHandler : MonoBehaviour
{
    [SerializeField]
    private BonusButton[] _bonusButtons;
    
    private BonusController _bonusController;

    private void Start()
    {
        foreach (BonusButton bonusButton in _bonusButtons)
        {
            bonusButton.OnButtonClicked += OnBonusButtonClicked;
        }
        
        _bonusController = FindObjectOfType<BonusController>();
    }

    private void OnDestroy()
    {
        foreach (BonusButton bonusButton in _bonusButtons)
        {
            bonusButton.OnButtonClicked -= OnBonusButtonClicked;
        }
    }

    public void HomeButtonClicked()
    {
        
    }

    private void OnBonusButtonClicked(BonusType bonusType, ResourceType resourceType, int cost)
    {
        if (bonusType == BonusType.AddBank)
        {
            _bonusController.TryAddBuilding(BuildingType.Bank, resourceType, cost);
        }
        else if (bonusType == BonusType.AddButchery)
        {
            _bonusController.TryAddBuilding(BuildingType.Butchery, resourceType, cost);
        }
        else if (bonusType == BonusType.AddCharacter)
        {
            _bonusController.TryAddCharacter();
        }
        else if (bonusType == BonusType.SpeedUp)
        {
            _bonusController.TryIncreaseSpeed();
        }
    }
}
