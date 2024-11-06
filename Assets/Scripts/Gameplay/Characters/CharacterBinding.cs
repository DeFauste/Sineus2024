using UnityEngine;

namespace Assets.Scripts.Gameplay.Characters
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class CharacterBinding:MonoBehaviour
    {
        public CharacterData CharacterData;
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            InitView();
        }
        public void InitView()
        {
            if(CharacterData.Animation != null) _animator.runtimeAnimatorController = CharacterData.Animation;
        }
    }
}
