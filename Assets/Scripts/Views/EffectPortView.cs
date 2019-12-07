using System.Collections;
using UnityEngine;

namespace Scripts.Views
{
    public class EffectPortView : MonoBehaviour
    {
        [SerializeField] private GameObject _port;
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
            var cnt = 0;
            while (cnt < 500)
            {
                instance.transform.position += instance.gameObject.transform.forward * Time.deltaTime*30;
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