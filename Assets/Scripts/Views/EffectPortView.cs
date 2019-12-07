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
            var obj = Resources.Load("FireBall");
            var instance = (GameObject) Instantiate(obj,
                new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.x),
                Quaternion.identity);
            instance.transform.SetParent(_port.transform);
            instance.transform.rotation = this.transform.rotation;
            var cnt = 0;
            while (cnt < 500)
            {
                Debug.Log(cnt);
                instance.transform.position += instance.gameObject.transform.forward * Time.deltaTime*50;
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