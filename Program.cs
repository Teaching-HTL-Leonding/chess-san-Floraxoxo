Console.Clear();
int number = 0;
for (int i = 0; i < args.Length; i++)
{
    if (args.Length < i) {number = i+1;} else {number = 0;}
    var r = new ChessGame(args[i], args[number], ref i);
}