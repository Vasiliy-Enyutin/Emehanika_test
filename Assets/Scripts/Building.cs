using Enums;
using UnityEngine;

public class Building : MonoBehaviour
{
        [SerializeField]
        private BuildingType _buildingType;
        [SerializeField]
        private ResourceType _resourceType;
        [SerializeField]
        private int _resourcesCount;

        public BuildingType BuildingType => _buildingType;
        public ResourceType ResourceType => _resourceType;
        public int ResourcesCount => _resourcesCount;
}