using GFA.MiniGames.Data;
using UnityEngine;

namespace GFA.MiniGames.Games
{
    [CreateAssetMenu(menuName = "Games/Memory Match", fileName = "MemoryMatch", order = 0)]
    public class MemoryMatch : MiniGame
    {
        [SerializeField]
        private MemoryMatchUI _uiPrefab;

        private MemoryMatchUI _uiInstance;
        
        protected override void OnBegin()
        {
            _uiInstance = Instantiate(_uiPrefab, Context.Viewport);

            _uiInstance.GenerateCards();
        }

        protected override void OnTick()
        {
        }

        protected override void OnEnd()
        {
            Destroy(_uiInstance);
        }
    }
}
