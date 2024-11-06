using UnityEngine;

public class Rune : MonoBehaviour
{
    [field: SerializeField] public Elements Element { get; private set; }
    public bool IsAvailable { get; private set; }
}