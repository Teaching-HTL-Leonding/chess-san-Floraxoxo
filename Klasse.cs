public class ChessGame
{
    public const string Vmove = "moves to ";
    public const string Vcapture = "captures ";
    public string endMessage;
    public bool shouldPrint;
    public ChessGame(string moves, string nextMove, ref int i)
    {
        if (moves != "e.p.")
        {
            CheckWhoMoves(moves[0]);
            CheckWhichMove(moves, nextMove);
            Console.WriteLine(endMessage);
        }
    }
    private string CheckWhoMoves(char move)
    {
        switch (move)
        {
            case 'K': endMessage += "King "; return "King";
            case 'Q': endMessage += "Queen "; return "Queen";
            case 'R': endMessage += "Rook "; return "Rook";
            case 'B': endMessage += "Bishop "; return "Bishop"; ;
            case 'N': endMessage += "Knight "; return "Knight";
            default: endMessage += "Pawn "; return "Pawn";
        }
    }
    private void CheckWhichMove(string move, string nextMove)
    {
        char firstChar = move[0];
        if (char.IsUpper(firstChar))
        {
            if (move.Contains("x")) { endMessage += Vcapture + "the piece on " + move.Substring(2); }
            else if (move.Length == 5) { endMessage += $"on {move.Substring(1, 2)} " + Vmove + move.Substring(3); }
            else
            {
                if (char.IsNumber(move[1])) { endMessage += $"on the {move[1]}-file "; }
                else { endMessage += $"on the {move[1]}-rank "; }
                endMessage += Vmove + move.Substring(2);
            }
        }
        else
        {
            if (move.Contains("x") && nextMove == "e.p.") { endMessage += $"on the {move[0]}-file " + Vcapture + "a piece en passant on " + move.Substring(2); }
            else if (move.Contains("x")) { endMessage += $"on the {move[0]}-file " + Vcapture + "the piece on " + move.Substring(2); }
            else if (move != "e.p.")
            {
                if (char.IsLetter(move[2]) && char.IsUpper(move[2])) { endMessage += Vmove + move.Substring(0, 2) + $" and is promoted as {CheckWhoMoves(move[2])}"; }
                else { endMessage += Vmove + move; }
            }
        }
    }
}