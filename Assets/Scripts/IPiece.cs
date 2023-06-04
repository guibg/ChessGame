using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPiece
{
    public abstract bool CanMove(Vector2Int targetPos, Piece piece, bool forced = false);
    public abstract bool CanTake(Vector2Int targetPos, Piece piece);
    public abstract bool IsMoveLegal(Vector2Int targetPos, Piece piece);
}

public enum PieceType
{
    Pawn,
    Rook,
    Knight,
    Bishop,
    Queen,
    King
}
