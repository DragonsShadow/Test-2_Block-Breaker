using Logic;
using Model;
using UnityEngine;

namespace View
{
    public class PLayerManager : MonoBehaviour
    {
        [SerializeField] private Transform player;
        private PlayerModel _playerModel;

        private void Start()
        {
            _playerModel = ScriptableObject.CreateInstance<PlayerModel>();
            _playerModel = Resources.Load<PlayerModel>("GameConfigs/PlayerModel");
        }

        private void Update()
        {
            PlayerMovement();
        }

        private void PlayerMovement()
        {
            if (Input.anyKey && WinOrLoseManager.IsStarted)
            {
                LevelObjectsMover.PlayerMovement(player);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision2dObject)
        {
            if (collision2dObject.collider.tag.Equals("Ball"))
            {
                LevelObjectsMover.BallMovementEnhance(transform, collision2dObject);
            }
        }
    }
}