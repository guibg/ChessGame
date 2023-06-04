using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingController : IPiece
{
    public override bool CanMove(Vector2Int targetPos, Piece piece, bool forced = false)
    {
        if (!forced) if (!IsMoveLegal(targetPos, piece)) return false;
        return true;
    }
    public override bool CanTake(Vector2Int targetPos, Piece piece)
    {
        return CanMove(targetPos, piece);
    }
    public override bool IsMoveLegal(Vector2Int targetPos, Piece piece)
    {
        int distanceX = Mathf.Abs(targetPos.x - piece.position.x);
        int distanceY = Mathf.Abs(targetPos.y - piece.position.y);
        if (distanceX <= 1 && distanceY <= 1) return true;
        return false;
    }
}
