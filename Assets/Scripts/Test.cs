using Assets.Scripts.Gameplay.Characters;
using Assets.Scripts.Gameplay.Deck.Managers;
using Assets.Scripts.Gameplay.Spell;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private BaseCharacter _player;
    [SerializeField] private BaseCharacter _enemy;
    SingleAttack _singleAttack;
    [SerializeField] DillerCard _dillerCard;

    void Start()
    {
        _singleAttack = new SingleAttack(_player, _enemy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _singleAttack.Interact();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {

        }
    }
}
