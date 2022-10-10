using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "PlayerModel", menuName = "PlayerModel", order = 3)]
    public class PlayerModel : ScriptableObject
    {
        public Vector3 playerStartLocation = new Vector3(0, 0, 0);
        public Vector3 playerSpeed = new Vector3(1, 0, 0);
    }
}