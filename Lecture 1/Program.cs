class Program
{
    static void Main(string[] args)
    {
        Times times = new Times
        (
            new Plus
            (
                new Var
                (
                    new Value("a")
                ),
                new Var
                (
                    new Value("b")
                )
            ),
            new Int
            (
                new Value("1")
            )
        );

        times.PrintDfs();
    }
}

class Parser
{
    public string[] Parse(string str)
    {
        return str.Split(" ");

    }
}

abstract class Node
{
    public abstract void PrintDfs();

    protected void print()
    {
        Console.WriteLine(this.ToString());
    }

    protected void print(string value)
    {
        Console.WriteLine(value);
    }
}

abstract class UnaryNode : Node
{
    public override void PrintDfs()
    {
        this.print();
        _node.PrintDfs();
    }

    Node _node;

    protected UnaryNode(Node node)
    {
        _node = node;
    }
}

abstract class BinaryNode : Node
{
    public override void PrintDfs()
    {
        this.print();
        _left.PrintDfs();
        _right.PrintDfs();
    }

    Node _right;
    Node _left;

    protected BinaryNode(Node left, Node right)
    {
        _left = left;
        _right = right;
    }
}

class Plus : BinaryNode
{
    public Plus(Node left, Node right) : base(left, right)
    {
    }
}

class Times : BinaryNode
{
    public Times(Node left, Node right) : base(left, right)
    {
    }
}

class Value : Node
{
    public override void PrintDfs()
    {
        print(_value);
    }
    string _value;

    public Value(string value)
    {
        _value = value;
    }
}

class Var : UnaryNode
{
    public Var(Value value) : base(value)
    {
    }
}

class Int : UnaryNode
{
    public Int(Value value) : base(value)
    {
    }
}



