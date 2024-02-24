using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
	[RequireComponent(typeof(UiTransitionController))]
	public class MenuController : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] _storyPanels;
		[SerializeField]
		private GameObject _mainMenuPanel;
		[SerializeField]
		private GameObject _settingsPanel;
		[SerializeField]
		private GameObject _ratePanel;

		private const int GAMEPLAY_SCENE_INDEX = 1;
		
		private int _currentStoryPanelIndex = 0;
		private UiTransitionController _uiTransitionController;

		void Awake()
		{
			_uiTransitionController = GetComponent<UiTransitionController>();
			
			for (int i = 0; i < _storyPanels.Length; i++)
			{
				_storyPanels[i].SetActive(i == 0);
			}
		}

		void Update()
		{
			if (!_uiTransitionController.IsFading && Input.GetMouseButtonDown(0))
			{
				if (_currentStoryPanelIndex < _storyPanels.Length - 1)
				{
					StartCoroutine(_uiTransitionController.TransitionToNextObject(_storyPanels[_currentStoryPanelIndex], _storyPanels[++_currentStoryPanelIndex]));
				}
				else if (!_mainMenuPanel.activeSelf)
				{
					StartCoroutine(_uiTransitionController.TransitionToNextObject(_storyPanels[_currentStoryPanelIndex], _mainMenuPanel));
				}
			}
		}

		public void OnSettingsButtonClicked()
		{
			_ratePanel.SetActive(false);
			_settingsPanel.SetActive(true);
		}
		
		public void OnRateButtonClicked()
		{
			_settingsPanel.SetActive(false);
			_ratePanel.SetActive(true);
		}

		public void OnPlayButtonClicked()
		{
			SceneManager.LoadScene(GAMEPLAY_SCENE_INDEX);
		}
	}
}
