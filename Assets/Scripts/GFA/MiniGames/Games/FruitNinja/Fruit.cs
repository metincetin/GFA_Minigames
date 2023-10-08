using UnityEngine;

namespace GFA.MiniGames.Games.FruitNinja
{
    public class Fruit : MonoBehaviour, ICuttable
    {
        public void Cut(Vector3 normal, float distance)
        {
            Destroy(gameObject);
            
            // unsigned
            // Vector3.Distance(Vector3.zero, Vector3.up) == 1;
            // signed
            // Vector3.Dot(Vector3.up - Vector3.zero, -Vector3.up) == 1;
            
            // example:
            //(0, 1, 0) - (0,0,0) = (0,1,0) * (0,1,0) = 1
            //(0, 1, 0) - (0,0,0) = (0,1,0) * (0,-1,0) = -1
        }
    }
}
