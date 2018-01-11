using Calculator;

namespace BinaryTreeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
        Tree calc =new Tree();
        string exp = "";
        if(calc.BuildTree(exp)){
        Node root = calc.root;
        System.Console.WriteLine(calc.Calculate(root));
            }
        }
    }
}
