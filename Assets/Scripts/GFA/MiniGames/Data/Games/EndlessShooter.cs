using UnityEngine;
using UnityEngine.SceneManagement;

namespace GFA.MiniGames.Data.Games
{
    [CreateAssetMenu(menuName = "Games/Endless Shooter", fileName = "EndlessShooter", order = 0)]
    public class EndlessShooter : MiniGame
    {
        [SerializeField]
        private string _sceneName;
        
        protected override void OnBegin()
        {
            SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
        }

        protected override void OnTick()
        {
        }

        protected override void OnEnd()
        {
            SceneManager.UnloadSceneAsync(_sceneName);
        }
    }
}
