using Assets.Scripts.EventMessages;
using MessagePipe;
using System;
using UnityEngine;

namespace Assets.Scripts.Spell
{
    public class Spell : MonoBehaviour, ISpell
    {
        [SerializeField] protected Elements typeOne;
        [SerializeField] protected Elements typeTwo;
        protected Player.Player _player;
        protected Enemy.Enemy _enemy;
        public virtual void DoSpell()
        {
            
        }

        public virtual Vector2Int GetTypeSpell()
        {
            return new Vector2Int((int)typeOne, (int) typeTwo);
        }

        public void Init(Player.Player player, Enemy.Enemy enemy)
        {
            _enemy = enemy;
            _player = player;
        }
    }
}
