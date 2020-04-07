using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Broom_Game.Scripts
{
    public class Spot : MonoBehaviour
    {
        private int _health = 100;
        private bool _isDead;
        private static int damage = 20;

        public void Brush()
        {
            if (_isDead)
                return;

            _health -= damage;

            var m = GetComponent<Renderer>().material;
            var c = m.color;
            m.SetColor("_Color", new Color(c.r, c.g, c.b, _health / 100f));

            GetComponentInChildren<ParticleSystem>().Play();

            if (_health <= 0)
            {
                _isDead = true;
                StartCoroutine(Destroy(GetComponentInChildren<ParticleSystem>()));
            }
                
        }

        private IEnumerator Destroy(ParticleSystem ps)
        {
            yield return new WaitWhile(() => ps.isPlaying);
            Destroy(gameObject);
        }
    }
}
