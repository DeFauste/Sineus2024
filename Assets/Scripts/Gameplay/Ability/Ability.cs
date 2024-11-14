using Assets.Scripts.Gameplay.Characters;

namespace Assets.Scripts.Gameplay.Ability
{

    public abstract class Ability
    {
        protected CharacterData _playerData;
        protected CharacterData _enemyData;
        protected Ability(CharacterData playerData, CharacterData enemyData)
        {
            _enemyData = enemyData;
            _playerData = playerData;
        }
        public abstract void Activate();
        
    }
}
