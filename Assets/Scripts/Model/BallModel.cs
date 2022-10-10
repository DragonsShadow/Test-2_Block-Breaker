using UnityEngine;

namespace Model
{
    [CreateAssetMenu(fileName = "BallModel", menuName = "BallModel", order = 4)]
    public class BallModel : ScriptableObject
    {
        public int minimumHorizontalRange = -250;
        public int maximumHorizontalRange = 250;
        public Vector3 ballStartLocation = new Vector3(0, -3.8f, 0);
        public Vector3 ballFirstSpeed = new Vector3(0, -250f, 0);
    }
}