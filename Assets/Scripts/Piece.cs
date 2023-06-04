using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    public bool isWhite;
    public PieceType type;
    public Vector2Int position;
    public bool hasMoved = false;

    public Piece(bool isWhite, PieceType type, Vector2Int position)
    {
        this.isWhite = isWhite;
        this.type = type;
        this.position = position;
    }
}
