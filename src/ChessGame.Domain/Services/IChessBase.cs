﻿namespace ChessGame.Domain;

public interface IChessBase
{
    ChessColor Color { get; }
    string Unicode { get; }
}