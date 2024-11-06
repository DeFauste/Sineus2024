using UnityEngine;

public class RunesController : MonoBehaviour
{
    [SerializeField] private RuneMergeSystem _runeMergeSystem;
    [SerializeField] private RuneTransporter _runeTransporter;
    
    public void Awake()
    {
        _runeTransporter.RuneFound += SetRune;
        _runeTransporter.StartCreateSpell += MergeRunes;
    }

    private void SetRune(Rune rune, int currentRune)
    {
        _runeMergeSystem.SetRune(rune, currentRune);
    }

    private void MergeRunes()
    {
        _runeMergeSystem.MergeRunes();
    }
    private void OnDestroy()
    {
        _runeTransporter.RuneFound -= SetRune;
        _runeTransporter.StartCreateSpell -= MergeRunes;
    }
}