using Enums;
using UnityEngine;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        private readonly InventoryModel _inventoryModel = new();
        private InventoryView _inventoryView;

        private void Start()
        {
            _inventoryView = FindObjectOfType<InventoryView>();
        }

        public void AddResource(ResourceType resourceType, int count)
        {
            _inventoryModel.AddResource(resourceType, count);
            _inventoryView.UpdateResourceCount(resourceType, count);
        }

        public bool TryGetResource(ResourceType resourceType, int count)
        {
            if (!_inventoryModel.TryGetResource(resourceType, count))
            {
                return false;
            }

            _inventoryView.UpdateResourceCount(resourceType, -count);
            return true;
        }
    }
}
