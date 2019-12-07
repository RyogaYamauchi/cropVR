using System.Collections;
using Scripts.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts.Views
{
    public class StartEffectView : MonoBehaviour
    {
        private Rigidbody rb;
        private Image _image;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void OnCollisionEnter(Collision collision)
        {
            SceneManager.LoadScene("Scenes/SampleScene");
        }
        
    }
}