using Core.Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.Gameplay.Audio
{
    public class ButtonMainUI: MonoBehaviour
    {
        Button[] buttons;
        private AudioService _audioService;
        [SerializeField] private Slider _musicSlider;
        [Inject]
        public void Construct(AudioService audioSource)
        {
            _audioService = audioSource;
        }
        public void Start()
        {
            if (_musicSlider != null) _audioService.SetMusicVolume(_musicSlider.value);
            FindButtonScene();
        }

        private void FindButtonScene()
        {
            buttons = FindObjectsOfType<Button>(true);

            foreach (Button button in buttons)
            {
                button.onClick.AddListener(() =>_audioService.PlaySfx("Open"));
            }
        }
    }
}
