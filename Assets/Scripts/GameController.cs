using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameController
{
    public static PieceController[,] pieces = new PieceController[8, 8];
    public static bool isWhiteTurn = true;
}