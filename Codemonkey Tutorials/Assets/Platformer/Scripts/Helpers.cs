using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    public static void DrawDebugBox(Vector2 origin, Vector2 size, float duration, Color color)
    {
        Vector2 bottomLeft = new Vector2(origin.x - size.x / 2, origin.y - size.y / 2);
        Vector2 topLeft = new Vector2(origin.x - size.x / 2, origin.y + size.y / 2);
        Vector2 topRight = new Vector2(origin.x + size.x / 2, origin.y + size.y / 2);
        Vector2 bottomRight = new Vector2(origin.x + size.x / 2, origin.y - size.y / 2);

        Debug.DrawLine(bottomLeft, bottomRight, color, duration);
        Debug.DrawLine(bottomLeft, topLeft, color, duration);
        Debug.DrawLine(topRight, topLeft, color, duration);
        Debug.DrawLine(topRight, bottomRight, color, duration);
    }
}
