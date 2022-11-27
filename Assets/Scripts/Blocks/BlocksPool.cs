using UnityEngine;

namespace IbragimovAA.Arcanoid
{
    public class BlocksPool : BasePool<Block>
    {
        public BlocksPool(Block prefab, Transform parent, int count = 1) : base(prefab, parent)
        {
            Init(count);
        }

        public override void Init(int count)
        {
            for (int i = 0; i < count; i++)
            {
                PoolUp(true);//заменено на true, чтобы блоки были видимы на старте
            }
        }

        protected override Block GetCreated()
        {
            return RandomizePositionAndRotation(4, 45);//вынести в инспектор
        }

        private Block RandomizePositionAndRotation(float randomPosition, float randomAngle)
        {
            var randomOffsetX = Random.Range(-randomPosition, randomPosition);
            var randomOffsetY = 5 + Random.Range(-randomPosition, randomPosition);
            var randomOffsetZ = Random.Range(-randomPosition, randomPosition);

            var randomAngleX = Random.Range(0, randomAngle);
            var randomAngleY = Random.Range(0, randomAngle);
            var randomAngleZ = Random.Range(0, randomAngle);

            var result = Object.Instantiate(_prefab, new Vector3(randomOffsetX, randomOffsetY, randomOffsetZ), Quaternion.Euler(randomAngleX, randomAngleY, randomAngleZ));
            return result;
        }
    }
}
