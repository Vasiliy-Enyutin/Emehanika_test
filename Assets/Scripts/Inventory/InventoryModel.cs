using System.Collections.Generic;

namespace Inventory
{
    public class InventoryModel
    {
        private readonly Dictionary<BuildingResource, int> _resourceToCount = new();
        
        public InventoryModel()
        {
            _resourceToCount.Add(BuildingResource.Meat, 0);
            _resourceToCount.Add(BuildingResource.Coin, 0);
        }
        
        public void AddResource(BuildingResource resource, int count)
        {
            if (_resourceToCount.ContainsKey(resource))
            {
                _resourceToCount[resource] += count;
            }
            else
            {
                _resourceToCount.Add(resource, count);
            }
        }
    }
}
