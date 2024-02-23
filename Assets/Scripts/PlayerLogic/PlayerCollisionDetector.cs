using Inventory;
using UnityEngine;

namespace PlayerLogic
{
    [RequireComponent(typeof(InventoryController))]
    public class PlayerCollisionDetector : MonoBehaviour
    {
        private InventoryController _inventoryController;
    
        private void Awake()
        {
            _inventoryController = GetComponent<InventoryController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Building building))
            {
                _inventoryController.AddResource(building.Resource, building.ResourcesCount);
            }
        }
    }
}