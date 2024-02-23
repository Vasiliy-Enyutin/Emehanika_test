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

        public void AddResource(BuildingResource resource, int count)
        {
            _inventoryModel.AddResource(resource, count);
            _inventoryView.UpdateResourceText(resource, count);
        }
    }
}
