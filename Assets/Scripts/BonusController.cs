using System;
using System.Collections.Generic;
using Enums;
using Inventory;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _disabledBanks;
    [SerializeField]
    private GameObject[] _disabledButcheries;

    private readonly Dictionary<BuildingType, GameObject[]> _disabledBuildings = new();
    private InventoryController _inventoryController;

    private void Awake()
    {
        _disabledBuildings.Add(BuildingType.Bank, _disabledBanks);
        _disabledBuildings.Add(BuildingType.Butchery, _disabledButcheries);
    }

    private void Start()
    {
        _inventoryController = FindObjectOfType<InventoryController>();
    }

    public void TryAddCharacter()
    {
        
    }

    public void TryAddBuilding(BuildingType buildingType, ResourceType resourceType, int cost)
    {
        if (_disabledBuildings.TryGetValue(buildingType, out GameObject[] buildingsArray))
        {
            foreach (GameObject building in buildingsArray)
            {
                if (building.activeSelf)
                {
                    continue;
                }
                if (!_inventoryController.TryGetResource(resourceType, cost))
                {
                    continue;
                }

                building.SetActive(true);
                break;
            }
        }
    }

    public void TryIncreaseSpeed()
    {
        
    }
}
