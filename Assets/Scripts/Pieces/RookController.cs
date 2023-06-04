using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookController : IPiece
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
        int directionX = Mathf.Clamp(targetPos.x - piece.position.x, -1, 1);
        int directionY = Mathf.Clamp(targetPos.y - piece.position.y, -1, 1);
        int distance = distanceX + distanceY;
        Vector2Int checkPos = piece.position;
        for (int i = 1; i < distance; i++)
        {
            checkPos.x += directionX;
            checkPos.y += directionY;
            if (GameController.pieces[checkPos.x, checkPos.y] != null) return false;
        }
        if (distanceX == 0 || distanceY == 0) return true;
        return false;
    }
}
