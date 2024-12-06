using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Core.Audio.Mixer
{
    public class AudioMixerController
    {
        private const string MasterVolumeParameter = "Master";
        private const string MusicVolumeParameter = "Music";
        private const string SfxVolumeParameter = "SFX";

        private readonly AudioMixer _audioMixer;
        public AudioMixerController(AudioMixer audioMixer)
        {
            _audioMixer = audioMixer;
        }


        public void SetMusicVolume(float volume)
        {
            _audioMixer.SetFloat(MusicVolumeParameter, Mathf.Log10(volume) * 20);
        }

        public void SetSfxVolume(float volume)
        {
            _audioMixer.SetFloat(SfxVolumeParameter, Mathf.Log10(volume) * 20);
        }

        public void SetMasterVolume(float volume)
        {
            _audioMixer.SetFloat(MasterVolumeParameter, Mathf.Log10(volume) * 20);
        }
    }
}
