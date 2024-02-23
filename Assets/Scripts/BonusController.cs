using System.Collections.Generic;
using Enums;
using Inventory;
using PlayerLogic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
	[SerializeField]
	private GameObject _playerPrefab;
	[SerializeField]
	private List<PlayerMovement> _playerCharacters;
    [SerializeField]
    private List<GameObject> _disabledBanks;
    [SerializeField]
    private List<GameObject> _disabledButcheries;
    [SerializeField]
    private int _extraCharactersCount;

    private readonly Dictionary<BuildingType, List<GameObject>> _disabledBuildings = new();
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

    public void TryAddCharacter(BonusButton bonusButton, ResourceType resourceType, int cost)
    {
	    if (!_inventoryController.TryGetResource(resourceType, cost))
	    {
		    return;
	    }

	    _playerCharacters.Add(Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity).GetComponent<PlayerMovement>());
	    _extraCharactersCount--;
	    
	    if (_extraCharactersCount <= 0)
	    {
		    bonusButton.ChangeStateToMax();
	    }
    }

    public void TryAddBuilding(BonusButton bonusButton, BuildingType buildingType, ResourceType resourceType, int cost)
    {
        if (_disabledBuildings.TryGetValue(buildingType, out List<GameObject> disabledBuildings))
        {
            foreach (GameObject building in disabledBuildings)
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
                disabledBuildings.Remove(building);
                break;
            }
            
            if (disabledBuildings.Count <= 0)
            {
				bonusButton.ChangeStateToMax();
            }
        }
    }

    public void TryIncreaseSpeed(ResourceType resourceType, int cost)
    {
	    if (!_inventoryController.TryGetResource(resourceType, cost))
	    {
		    return;
	    }
	    
	    foreach (PlayerMovement player in _playerCharacters)
	    {
		    player.IncreaseSpeedForever();
	    }
    }
}
