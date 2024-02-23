using System.Collections;
using Dreamteck.Splines;
using UnityEngine;

namespace PlayerLogic
{
    [RequireComponent(typeof(SplineFollower))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speedIncreaseValue;
        [SerializeField]
        private float _speedIncreaseDuration;
    
        private SplineFollower _splineFollower;

        private void Awake()
        {
            _splineFollower = GetComponent<SplineFollower>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(IncreaseSpeedForDuration());
            }
        }

        private IEnumerator IncreaseSpeedForDuration()
        {
            _splineFollower.followSpeed *= _speedIncreaseValue;
            yield return new WaitForSeconds(_speedIncreaseDuration);
            _splineFollower.followSpeed /= _speedIncreaseValue;
        }
    }
}