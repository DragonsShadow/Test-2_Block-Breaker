using Model;
using UnityEngine;

namespace Logic
{
    public class GameObjectsMover
    {
        private static PlayerModel _playerModel;
        private static BallModel _ballModel;
        private static bool _isStarted;

        public static void GameReset(Transform player, Transform ball)
        {
            _playerModel = Resources.Load<PlayerModel>("GameConfigs/PlayerModel");
            _ballModel = Resources.Load<BallModel>("GameConfigs/BallModel");
            player.localPosition = _playerModel.playerStartLocation;
            ball.localPosition = _ballModel.ballStartLocation;
        }

        public static bool GameStart(Rigidbody2D ball)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _isStarted = true;
                BallFisrtMovement(ball);
            }

            return _isStarted;
        }

        public static void PlayerMovement(Transform player)
        {
            if (Input.GetKey("d"))
            {
                player.localPosition += _playerModel.playerSpeed * Time.deltaTime;
            }

            if (Input.GetKey("a"))
            {
                player.localPosition -= _playerModel.playerSpeed * Time.deltaTime;
            }
        }

        private static void BallFisrtMovement(Rigidbody2D ball)
        {
            ball.AddForce(_ballModel.ballFirstSpeed);
            ball.AddForce(
                new Vector3(Random.Range(_ballModel.minimumHorizontalRange, _ballModel.maximumHorizontalRange), 0, 0));
        }
    }
}