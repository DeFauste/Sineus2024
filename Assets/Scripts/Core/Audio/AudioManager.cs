using UnityEngine;

namespace Core.Audio
{
    public class AudioManager : MonoBehaviour
    {
        private AudioService _audioService;

        //Добавить Inject AudioSrvice
        public void Construct(AudioService audioSource)
        {
            _audioService = audioSource;
        }

        public void Master(float value)
        {
            _audioService.SetMasterVolume(value);
        }
        public void Music(float value)
        {
            _audioService.SetMusicVolume(value);
        }
        public void SFX(float value)
        {
            _audioService.SetSfxVolume(value);
        }
    }
}
