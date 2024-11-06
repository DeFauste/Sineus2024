using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Spell
{
    public class SpellBuilder
    {
        string pathToResource = "CardSpell";
        private Dictionary<Vector2Int, GameObject> spells = new Dictionary<Vector2Int, GameObject>();
        protected Player.Player _player;
        protected Enemy.Enemy _enemy;
        
        public void UpdateEnemy(Player.Player player, Enemy.Enemy enemy)
        {
            _player = player;
            _enemy = enemy;
        }
        public void LoadSpells()
        {
            var spellsPref = Resources.LoadAll<GameObject>(pathToResource);
            BindPositionSpell(spellsPref);
        }

        private void BindPositionSpell(GameObject[] prefs)
        {
            if (prefs == null) return;
            for(int i = 0; i < prefs.Length; i++)
            {
                ISpell iSpell = prefs[i].GetComponent<ISpell>();
                if(iSpell != null)
                {
                    var key = iSpell.GetTypeSpell();
                    spells.Add(key,prefs[i]);
                }
            }
        }

        public GameObject CreateSpell(Vector2Int typeSpell)
        {

            GameObject spellPref;
            bool haveSpell = spells.TryGetValue(typeSpell,out spellPref);

            if (haveSpell == false)
            {
                var switchVector = new Vector2Int(typeSpell.y,typeSpell.x);
                haveSpell = spells.TryGetValue(switchVector,out spellPref);
            }
            if(haveSpell == false)
            {
                return null;
            }
            var spell = MonoBehaviour.Instantiate(spellPref);
            ISpell iSpell = spell.GetComponent<ISpell>();
            iSpell.Init(_player, _enemy);
            return spell;
        }
    }
}
