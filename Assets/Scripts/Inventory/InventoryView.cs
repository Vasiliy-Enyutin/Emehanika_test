using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [Serializable]
        public class ResourceData
        {
            public BuildingResource Resource;
            public int Count;
            public TextMeshProUGUI TextMeshPro;
        }

        [SerializeField]
        private List<ResourceData> _resourceDataList = new();

        private readonly Dictionary<BuildingResource, ResourceData> _resourceToResourceData = new();

        private void Awake()
        {
            InitializeResourceCounts();
        }

        public void UpdateResourceText(BuildingResource resource, int count)
        {
            if (!_resourceToResourceData.ContainsKey(resource))
            {
                return;
            }

            _resourceToResourceData[resource].Count += count;
            _resourceToResourceData[resource].TextMeshPro.text = _resourceToResourceData[resource].Count.ToString();
        }
        private void InitializeResourceCounts()
        {
            foreach (ResourceData resourceData in _resourceDataList)
            {
                _resourceToResourceData[resourceData.Resource] = resourceData;
                resourceData.TextMeshPro.text = resourceData.Count.ToString();
            }
        }
    }
}