using System;
using System.Collections.Generic;
using Enums;
using TMPro;
using UnityEngine;

namespace Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [Serializable]
        public class UiResourceData
        {
            public ResourceType resourceType;
            public int Count;
            public TextMeshProUGUI TextMeshPro;
        }

        [SerializeField]
        private List<UiResourceData> _resourceDataList = new();

        private readonly Dictionary<ResourceType, UiResourceData> _resourceToResourceData = new();

        private void Awake()
        {
            InitializeResourceCounts();
        }

        public void UpdateResourceCount(ResourceType resourceType, int count)
        {
            if (!_resourceToResourceData.ContainsKey(resourceType))
            {
                return;
            }

            _resourceToResourceData[resourceType].Count += count;
            _resourceToResourceData[resourceType].TextMeshPro.text = _resourceToResourceData[resourceType].Count.ToString();
        }
        private void InitializeResourceCounts()
        {
            foreach (UiResourceData resourceData in _resourceDataList)
            {
                _resourceToResourceData[resourceData.resourceType] = resourceData;
                resourceData.TextMeshPro.text = resourceData.Count.ToString();
            }
        }
    }
}