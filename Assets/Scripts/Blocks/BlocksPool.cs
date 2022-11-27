using UnityEngine;

namespace IbragimovAA.Arcanoid
{
    public class BlocksPool : BasePool<Block>
    {
        private int _randomRange;
        private int _randomAngle;
        public BlocksPool(Block prefab, Transform parent, int count = 1, int randomRange = 4, int randomAngle = 45) : base(prefab, parent)
        {
            _randomRange = randomRange;
            _randomAngle = randomAngle;
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
            return RandomizePositionAndRotation(_randomRange, _randomAngle);
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
