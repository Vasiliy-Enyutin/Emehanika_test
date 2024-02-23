using Inventory;
using UnityEngine;

namespace PlayerLogic
{
    public class PlayerCollisionDetector : MonoBehaviour
    {
        private InventoryController _inventoryController;
    
        private void Start()
        {
            _inventoryController = FindObjectOfType<InventoryController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Building building))
            {
                _inventoryController.AddResource(building.ResourceType, building.ResourcesCount);
            }
        }
    }
}