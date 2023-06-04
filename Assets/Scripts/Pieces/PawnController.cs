using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnController : IPiece
{
    public override bool CanMove(Vector2Int targetPos, Piece piece, bool forced = false)
    {
        if (!forced) if (!IsMoveLegal(targetPos, piece)) return false;
        return true;
    }
    public override bool CanTake(Vector2Int targetPos, Piece piece)
    {
        int distanceX = Mathf.Abs(targetPos.x - piece.position.x);
        int distanceY = targetPos.y - piece.position.y;
        if (!piece.isWhite)
        {
            distanceX *= -1;
            distanceY *= -1;
        }
        if (distanceX == 1 && distanceY == 1) return true;
        return false;
    }
    public override bool IsMoveLegal(Vector2Int targetPos, Piece piece)
    {
        int distanceX = targetPos.x - piece.position.x;
        int distanceY = targetPos.y - piece.position.y;
        int directionY = piece.isWhite ? 1 : -1;
        if (!piece.isWhite) distanceY *= -1;
        if (distanceY == 2 && GameController.pieces[targetPos.x, targetPos.y - directionY] != null) return false;
        if (distanceX == 0 && (distanceY == 1 || distanceY == 2 && !piece.hasMoved)) return true;
        //TODO: Add en passant
        return false;
    }
}
