using UnityEngine;

namespace IbragimovAA.Arcanoid
{
    public class GameManager : MonoBehaviour
    {
        private BlocksContainer _blocksContainer;
        private BlocksPool _blocksPool;
        void Start()
        {
            InitializeBlocksPool();
        }

        private void InitializeBlocksPool()
        {
            _blocksContainer = FindObjectOfType<BlocksContainer>();
            _blocksPool = new(Resources.Load<Block>("Prefabs/Block"), _blocksContainer.transform, 20);
        }
    }
}
