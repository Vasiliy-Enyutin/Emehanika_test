using System.Collections.Generic;
using Enums;

namespace Inventory
{
    public class InventoryModel
    {
        public readonly Dictionary<ResourceType, int> _resourceToCount = new();
        
        public InventoryModel()
        {
            _resourceToCount.Add(ResourceType.Meat, 0);
            _resourceToCount.Add(ResourceType.Coin, 0);
        }
        
        public void AddResource(ResourceType resourceType, int count)
        {
            if (_resourceToCount.ContainsKey(resourceType))
            {
                _resourceToCount[resourceType] += count;
            }
            else
            {
                _resourceToCount.Add(resourceType, count);
            }
        }

        public bool TryGetResource(ResourceType resourceType, int count)
        {
            if (!_resourceToCount.ContainsKey(resourceType))
            {
                return false;
            }
            if (_resourceToCount[resourceType] < count)
            {
                return false;
            }

            _resourceToCount[resourceType] -= count;
            return true;

        }
    }
}
