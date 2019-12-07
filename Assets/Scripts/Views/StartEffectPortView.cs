﻿using System.Collections;
using Scripts.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts.Views
{
    public class StartEffectPortView : MonoBehaviour, IEffectPortView
    {
        [SerializeField] private GameObject _port;
        [SerializeField] private AudioClip _audioClipExplosion;
        [SerializeField] private Image _image;
        private int count = 0;

        private void Start()
        {
            GameModel.Instance.GameView._effectPortView = this;
        }

        public IEnumerator PlayFireAnimation()
        {
            var a = _image.material.color.a;
            while (a>=0)
            {
                a -= 0.1f;
                yield return null;
            }
            SceneManager.LoadScene("Scenes/SampleScene");

            Debug.Log(count);

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
            while (cnt < 500)
            {
                instance.transform.position += instance.gameObject.transform.forward * Time.deltaTime * 30;
                cnt++;
                yield return null;
            }

            Destroy(instance.gameObject);
        }
    }
}