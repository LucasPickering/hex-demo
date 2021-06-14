using System;
using System.Linq;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    public GameObject cubePrefab;
    public int radius = 5;

    void Start()
    {

        var r = this.radius;
        for (int x = -r; x <= r; x++)
        {
            // If we just do [-r,r] for y as well, then we end up with a
            // diamond pattern instead of a super hexagon
            // https://www.redblobgames.com/grids/hexagons/#range
            var y_min = Math.Max(-r, -x - r);
            var y_max = Math.Min(r, -x + r);
            for (int y = y_min; y <= y_max; y++)
            {
                var pos = new Vector3(x, y, -x - y);
                var gameObject = Instantiate(this.cubePrefab, pos, Quaternion.identity);
                gameObject.transform.parent = this.transform;
                gameObject.name = String.Format("Cube {0}", pos.ToString());
            }
        }
    }

}
