using System;
using JetBrains.Annotations;
using MessagePipe;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

public class ScenesController : MonoBehaviour
{
    private int _indexGameScene = 1;
    private IDisposable _subscriptions;

    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    [UsedImplicitly]
    public void LoadGame()
    {
        SceneManager.LoadScene(_indexGameScene);
        Debug.Log("load");
    }

    private void OnDestroy()
    {
        _subscriptions.Dispose();
    }
}