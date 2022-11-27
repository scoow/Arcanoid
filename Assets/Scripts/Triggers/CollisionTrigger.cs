using UnityEngine;

namespace IbragimovAA.Arcanoid
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
                case TypeOfTrigger.Gate:
                    GameManager.instance.LoseLife();
                    break;
                default:
                    break;
            }
        }
        private enum TypeOfTrigger
        {
            Wall,
            FloorOrCeiling,
            Gate,
        }
    }
}

