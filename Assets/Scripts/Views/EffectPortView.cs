using System;
using System.Collections;
using Scripts.Models;
using UnityEngine;

namespace Scripts.Views
{
    public class EffectPortView : MonoBehaviour, IEffectPortView
    {
        [SerializeField] private GameObject _port;
        [SerializeField] private AudioClip _audioClipExplosion;
        public  AudioSource _audioSource;

        private void Start()
        {
            GameModel.Instance.GameView._effectPortView = this;

        }

        public IEnumerator PlayPlasmaAnimation()
        {
            yield break;
        }

        public IEnumerator PlayFireAnimation()
        {
            _port.transform.position = this.transform.position;
            var obj = Resources.Load("FireBall");
            var instance = (GameObject) Instantiate(obj,
                new Vector3(_port.transform.position.x, _port.transform.position.y, _port.transform.position.z),
                Quaternion.identity);
            instance.transform.SetParent(_port.transform);
            instance.transform.rotation = this.transform.rotation;
            instance.AddComponent<AudioSource>();
            var audioSource = instance.GetComponent<AudioSource>();
            audioSource.clip = _audioClipExplosion;
            audioSource.volume = 0.5f;
            audioSource.Play(0);
            var cnt = 0;
            while (cnt < 700)
            {
                instance.transform.position += instance.gameObject.transform.forward * Time.deltaTime * 15;
                cnt++;
                yield return null;
            }

            Destroy(instance.gameObject);
        }

        public IEnumerator PlayWaterAnimation()
        {
            yield break;
        }
    }
}