using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "PlayerModel", menuName = "PlayerModel", order = 4)]
    public class PlayerModel : ScriptableObject
    {
        public Vector3 playerSpeed = new Vector3(1, 0, 0);
    }
}