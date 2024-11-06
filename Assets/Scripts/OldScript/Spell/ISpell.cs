using UnityEngine;

namespace Assets.Scripts.Spell
{
    public interface ISpell
    {
        Vector2Int GetTypeSpell();
        void DoSpell();
        void Init(Player.Player player, Enemy.Enemy enemy);
    }
}
