
using Model;
using UnityEngine;
using View;
using Vector3 = UnityEngine.Vector3;

namespace Logic
{
    public class LevelAndPhysicsGenerateDataManager
    {
        private static PlayerModel _playerModel;
        private static BallModel _ballModel;

        public static void GameReset(Transform player, Rigidbody2D ball)
        {
            _playerModel = Resources.Load<PlayerModel>("GameConfigs/PlayerModel");
            _ballModel = Resources.Load<BallModel>("GameConfigs/BallModel");
            player.localPosition = _playerModel.playerStartLocation;
            ball.transform.localPosition = _ballModel.ballStartLocation;
            ball.velocity = Vector3.zero;
        }

        public static void GameStart(Rigidbody2D ball)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameUiManager.IsStarted = true;
                BallFisrtMovement(ball);
            }
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