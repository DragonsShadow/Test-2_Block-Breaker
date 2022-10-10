using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "BallModel", menuName = "BallModel", order = 4)]
    public class BallModel : ScriptableObject
    {
        public Vector3 ballStartLocation = new Vector3(0, -3.8f, 0);
        public Vector3 ballFirstSpeed = new Vector3(Random.Range(-250f, 250f), -250f, 0);
    }
}