using UnityEngine;

namespace Homework13A
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterMover _characterMover;

        [SerializeField] private ParticleSystem _dieEffect;
        [SerializeField] private ParticleSystem _winEffect;

        public bool IsAlive { get; private set; }

        public void Initialize()
        {
            _characterMover.Initialize();
            Enable();
        }

        private void Update()
        {
            if (IsAlive == false)
                return;
        }

        public void Disable()
        {
            gameObject.SetActive(false);
            IsAlive = false;
        }

        public void Enable()
        {
            gameObject.SetActive(true);
            IsAlive = true;
        }

        public void Kill()
        {
            Disable();
            PlayEffect(_dieEffect);
        }

        public void Win()
        {
            //Disable();
            PlayEffect(_winEffect);
        }

        private void PlayEffect(ParticleSystem effect)
        {
            if (effect == null)
                return;

            effect.transform.position = transform.position;
            effect.Play();
        }
    }
}