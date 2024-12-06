﻿using Core.Audio.Data;
using Core.Audio;
using UnityEngine.Audio;
using Zenject;
using UnityEngine;

namespace Assets.Scripts.Core.Services.Installers
{
    internal class AudioServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var audioMixer = Resources.Load<AudioMixer>("AudioMixer");
            if (audioMixer == null)
            {
                Debug.LogError($"Audio Mixer not found in resources");
                return;
            }

            var audioLibrary = Resources.Load<AudioLibrary>("AudioLibrary");
            if (audioLibrary == null)
            {
                Debug.LogError($"Audio Library not found in resources");
                return;
            }

            Container.Bind<AudioService>().AsSingle().WithArguments(audioMixer, audioLibrary).NonLazy();
            Debug.Log($"Audio Service installed to Project Context");
        }
    }
}
