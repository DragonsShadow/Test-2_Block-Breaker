using Model;
using UnityEngine;
using View;

namespace Logic
{
    public class LevelObjectsMover
    {
        private static PlayerModel _playerModel;
        private static BallModel _ballModel;

        public static void GameResetLocation(Transform player, Rigidbody2D ball)
        {
            _playerModel = Resources.Load<PlayerModel>("GameConfigs/PlayerModel");
            _ballModel = Resources.Load<BallModel>("GameConfigs/BallModel");
            player.localPosition = _playerModel.playerStartLocation;
            ball.transform.localPosition = _ballModel.ballStartLocation;
            ball.velocity = Vector3.zero;
        }

        public static void GameStartMove(Rigidbody2D ball)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                WinOrLoseManager.IsStarted = true;
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

        public static void EnhanceBallMovement(Transform player, Collision2D ball)
        {
            if (player.localPosition.x > ball.transform.localPosition.x)
            {
                ball.rigidbody.AddForce(new Vector3(-_playerModel.playerReshootBallForce, 0, 0));
            }

            if (player.localPosition.x < ball.transform.localPosition.x)
            {
                ball.rigidbody.AddForce(new Vector3(_playerModel.playerReshootBallForce, 0, 0));
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