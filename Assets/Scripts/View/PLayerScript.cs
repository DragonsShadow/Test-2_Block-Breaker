using Logic;
using Model;
using UnityEngine;

namespace View
{
    public class PLayerScript : MonoBehaviour
    {
        [SerializeField]private Transform player;
        private PlayerModel _playerModel;

        private void Start()
        {
            _playerModel = Resources.Load<PlayerModel>("GameConfigs/PlayerModel");
        }

        private void Update()
        {
            PlayerMovement();
        }

        private void PlayerMovement()
        {
            if (Input.anyKey && GameUiManager._isStarted)
            {
                LevelAndPhysicsGenerateDataManager.PlayerMovement(player);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.tag.Equals("Ball"))
            {
                
                if (transform.localPosition.x > col.transform.localPosition.x)
                {
                    col.rigidbody.AddForce(new Vector3(-_playerModel.playerReshootBallForce,0,0));
                }

                if (transform.localPosition.x < col.transform.localPosition.x)
                {
                    col.rigidbody.AddForce(new Vector3(_playerModel.playerReshootBallForce,0,0));
                }
            }
        }
    }
}