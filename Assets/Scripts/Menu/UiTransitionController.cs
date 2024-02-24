using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
	public class UiTransitionController : MonoBehaviour
	{
		[SerializeField]
		private Image _fadePanel;
		[SerializeField]
		private float _fadeDuration = 1f;

		public bool IsFading { get; private set; }

		private void Awake()
		{
			_fadePanel.gameObject.SetActive(false);
		}

		public IEnumerator TransitionToNextObject(GameObject currentPanel, GameObject newPanel)
		{
			IsFading = true;
			_fadePanel.gameObject.SetActive(true);

			float timer = 0f;
			while (timer < _fadeDuration)
			{
				timer += Time.deltaTime;
				float alpha = Mathf.Lerp(0f, 1f, timer / _fadeDuration);
				_fadePanel.color = new Color(0f, 0f, 0f, alpha);
				yield return null;
			}

			currentPanel.SetActive(false);
			newPanel.SetActive(true);
			timer = 0f;
			while (timer < _fadeDuration)
			{
				timer += Time.deltaTime;
				float alpha = Mathf.Lerp(1f, 0f, timer / _fadeDuration);
				_fadePanel.color = new Color(0f, 0f, 0f, alpha);
				yield return null;
			}

			IsFading = false;
			_fadePanel.gameObject.SetActive(false);
		}
	}
}