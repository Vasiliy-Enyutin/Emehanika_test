using UnityEngine;

public class Building : MonoBehaviour
{
        [SerializeField]
        private BuildingResource _buildingResource;
        [SerializeField]
        private int _resourcesCount;

        public BuildingResource Resource => _buildingResource;
        public int ResourcesCount => _resourcesCount;
}