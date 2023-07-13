using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePiece : Singleton<CreatePiece>
{
    [SerializeField] private GameObject piecePrefab;
    [SerializeField] private Sprite whitePawnSprite;
    [SerializeField] private Sprite blackPawnSprite;
    [SerializeField] private Sprite whiteRookSprite;
    [SerializeField] private Sprite blackRookSprite;
    [SerializeField] private Sprite whiteKnightSprite;
    [SerializeField] private Sprite blackKnightSprite;
    [SerializeField] private Sprite whiteBishopSprite;
    [SerializeField] private Sprite blackBishopSprite;
    [SerializeField] private Sprite whiteQueenSprite;
    [SerializeField] private Sprite blackQueenSprite;
    [SerializeField] private Sprite whiteKingSprite;
    [SerializeField] private Sprite blackKingSprite;

    public GameObject Instantiate(Piece piece)
    {
        GameObject pieceObject = GameObject.Instantiate(piecePrefab, new Vector3(piece.position.x, piece.position.y, 0), Quaternion.identity);
        pieceObject.GetComponent<PieceController>().Init(piece);
        pieceObject.GetComponent<SpriteRenderer>().sprite = piece.isWhite ? GetSprite(piece.type, true) : GetSprite(piece.type, false);
        GameController.pieces[piece.position.x, piece.position.y] = pieceObject.GetComponent<PieceController>();
        return pieceObject;
    }

    public Sprite GetSprite(PieceType type, bool isWhite)
    {
        Debug.Log("GetSprite");
        switch (type)
        {
            case PieceType.Pawn:
                return isWhite ? whitePawnSprite : blackPawnSprite;
            case PieceType.Rook:
                return isWhite ? whiteRookSprite : blackRookSprite;
            case PieceType.Knight:
                return isWhite ? whiteKnightSprite : blackKnightSprite;
            case PieceType.Bishop:
                return isWhite ? whiteBishopSprite : blackBishopSprite;
            case PieceType.Queen:
                return isWhite ? whiteQueenSprite : blackQueenSprite;
            case PieceType.King:
                return isWhite ? whiteKingSprite : blackKingSprite;
            default:
                return null;
        }
    }
}
