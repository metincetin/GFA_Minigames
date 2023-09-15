using GFA.Core.UI.Pagination;
using UnityEngine;

namespace GFA.MiniGames.UI.Pages
{
    public class GamePage : Page
    {
        [SerializeField] private RectTransform _viewport;
        public RectTransform Viewport => _viewport;
        
        protected override void OnOpened()
        {
        }

        protected override void OnClosed()
        {
        }
    }
}
