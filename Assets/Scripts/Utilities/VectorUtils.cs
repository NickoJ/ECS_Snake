namespace UnityEngine
{

    public static class VectorUtils
    {

        public static Vector2Int Range(Vector2Int min, Vector2Int max)
        {
            return new Vector2Int(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
        }

    }

}