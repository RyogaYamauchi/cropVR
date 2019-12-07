using System.Collections;
using Scripts.Models;
using UnityEngine;

namespace Scripts.Views
{
    public class EffectView : MonoBehaviour
    {
        private Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        void OnCollisionEnter(Collision collision)
        {
            StartCoroutine(DestroyOther(collision));
        }

        private IEnumerator DestroyOther(Collision collision)
        {
            GameModel.Instance.AddScore(10);
            var pos = collision.gameObject.transform.position;
            var obj = Resources.Load("TextTemplate");
            var instance = (GameObject) Instantiate(obj, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
            instance.gameObject.transform.SetParent(GameModel.Instance.GameView.Canvas.gameObject.transform);
            Destroy(collision.gameObject);
            yield return new WaitForSeconds(3.0f);
            Destroy(instance);
        }
    }
}