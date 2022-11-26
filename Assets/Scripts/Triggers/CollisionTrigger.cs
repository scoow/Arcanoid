using IbragimovAA.Arcanoid;
using UnityEngine;


namespace bragimovAA.Arcanoid
{
    public class CollisionTrigger : MonoBehaviour
    {
        [SerializeField]
        private TypeOfTrigger _typeOfTrigger;

        private void OnTriggerEnter(Collider other)
        {
            Ball ball = other.GetComponent<Ball>();
            if (ball is null)
                return;

            switch (_typeOfTrigger)
            {
                case TypeOfTrigger.Wall:
                    ball.ReflectX();
                    break;
                case TypeOfTrigger.FloorOrCeiling:
                    ball.ReflectY();
                    break;
                case TypeOfTrigger.Platform:
                    ball.ReflectZ();
                    break;
                case TypeOfTrigger.Gate:
                    ball.Deactivate();
                    break;
                case TypeOfTrigger.Block:
                    ball.ReflectX();
                    ball.ReflectY();
                    ball.ReflectZ();
                    gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }
        private enum TypeOfTrigger
        {
            Wall,
            FloorOrCeiling,
            Platform,
            Gate,
            Block
        }
    }
}
