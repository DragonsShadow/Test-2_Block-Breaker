using Model;
using UnityEngine;

namespace Logic
{
    public class PlayerMover
    {
        private static PlayerModel _playerModel;

        public static void PlayerMovement(Transform player)
        {
            _playerModel = Resources.Load<PlayerModel>("GameConfigs/PlayerModel");
            if (Input.GetKey("d"))
            {
                player.localPosition += _playerModel.playerSpeed * Time.deltaTime;
            }

            if (Input.GetKey("a"))
            {
                player.localPosition -= _playerModel.playerSpeed * Time.deltaTime;
            }
        }
    }
}