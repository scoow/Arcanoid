using UnityEngine;

namespace IbragimovAA.Arcanoid
{
    public class Block : MonoBehaviour
    {
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Ball ball = collision.collider.gameObject.GetComponent<Ball>();
            if (ball == null)
                return;
            ball.ComplexReflect(collision);
            Debug.Log("Collision");
            gameObject.SetActive(false);
        }
    }
}
