using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    [System.NonSerialized]
    public Piece _piece;
    [System.NonSerialized]
    public IPiece _iPiece;
    [System.NonSerialized]
    public bool _isDragging = false;
    [System.NonSerialized]
    public Vector2 initialPosition;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Init(Piece piece)
    {
        _piece = piece;
        _iPiece = GetIPiece(piece.type);
    }

    private IPiece GetIPiece(PieceType type)
    {
        switch (type)
        {
            case PieceType.Pawn:
                return new PawnController();
            case PieceType.Rook:
                return new RookController();
            case PieceType.Knight:
                return new KnightController();
            case PieceType.Bishop:
                return new BishopController();
            case PieceType.Queen:
                return new QueenController();
            case PieceType.King:
                return new KingController();
            default:
                return null;
        }
    }
    private void OnMouseDown()
    {
        _isDragging = true;
        _spriteRenderer.sortingLayerName = "DraggingPiece";
        initialPosition = transform.position;
    }
    private void OnMouseDrag()
    {
        if (_isDragging)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (objPosition.x < MapBounds.min.x) objPosition.x = MapBounds.min.x;
            if (objPosition.x > MapBounds.max.x) objPosition.x = MapBounds.max.x;
            if (objPosition.y < MapBounds.min.y) objPosition.y = MapBounds.min.y;
            if (objPosition.y > MapBounds.max.y) objPosition.y = MapBounds.max.y;
            transform.position = objPosition;
        }
    }
    private void OnMouseUp()
    {
        _isDragging = false;
        _spriteRenderer.sortingLayerName = "Piece";
        Vector2Int targetPosition = new Vector2Int((int)(transform.position.x + 0.5f), (int)(transform.position.y + 0.5f));
        if (isLegalMove(targetPosition))
        {
            Move(targetPosition);
            return;
        }
        CancelMove();
    }

    private bool isLegalMove(Vector2Int targetPosition)
    {
        //TODO: Add check for check
        //TODO: Add check for checkmate
        //TODO: Add check for stalemate
        //TODO: Add check for en passant
        //TODO: Add check for castling
        //TODO: Add check for pawn promotion
        if (GameController.isWhiteTurn != _piece.isWhite || targetPosition == initialPosition) return false;

        PieceController targetPiece = GameController.pieces[targetPosition.x, targetPosition.y];
        if (targetPiece != null && targetPiece._piece.isWhite == _piece.isWhite) return false;
        if (targetPiece == null && _iPiece.CanMove(targetPosition, _piece)) return true;
        if (targetPiece != null && _iPiece.CanTake(targetPosition, _piece)) return true;
        return false;
    }

    private void Move(Vector2Int targetPosition)
    {
        if (GameController.pieces[targetPosition.x, targetPosition.y] != null)
            Destroy(GameController.pieces[targetPosition.x, targetPosition.y].gameObject);
        GameController.isWhiteTurn = !GameController.isWhiteTurn;
        GameController.pieces[targetPosition.x, targetPosition.y] = this;
        GameController.pieces[_piece.position.x, _piece.position.y] = null;
        _piece.position = targetPosition;
        transform.position = new Vector3(targetPosition.x, targetPosition.y, 0);
        initialPosition = targetPosition;
        _piece.hasMoved = true;
    }

    private void CancelMove()
    {
        transform.position = initialPosition;
    }
}
