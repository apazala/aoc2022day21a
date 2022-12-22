
class TreeOp
{
    public char op;
    public long n;
    string name;
    public TreeOp left;
    public TreeOp right;

    public TreeOp(string name)
    {
        this.name = name;
    }

    public long Shout()
    {
        switch (op)
        {
            case 's': return n;
            case '+': return left.Shout() + right.Shout();
            case '-': return left.Shout() - right.Shout();
            case '*': return left.Shout() * right.Shout();
            case '/': return left.Shout() / right.Shout();
        }

        return -1;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, TreeOp> monkeys = new Dictionary<string, TreeOp>();
        string[] lines = File.ReadAllLines("input.txt");
        char[] seps = { ' ', ':' };
        foreach (string line in lines)
        {
            string[] nameArgs = line.Split(seps, StringSplitOptions.RemoveEmptyEntries);
            TreeOp monke;
            if (!monkeys.TryGetValue(nameArgs[0], out monke))
            {
                monke = new TreeOp(nameArgs[0]);
                monkeys[nameArgs[0]] = monke;
            }

            if (nameArgs.Length == 2)
            {
                monke.n = long.Parse(nameArgs[1]);
                monke.op = 's';
            }
            else
            {
                TreeOp monkeL, monkeR;

                if (!monkeys.TryGetValue(nameArgs[1], out monkeL))
                {
                    monkeL = new TreeOp(nameArgs[1]);
                    monkeys[nameArgs[1]] = monkeL;
                }

                if (!monkeys.TryGetValue(nameArgs[3], out monkeR))
                {
                    monkeR = new TreeOp(nameArgs[3]);
                    monkeys[nameArgs[3]] = monkeR;
                }

                monke.op = nameArgs[2][0];
                monke.left = monkeL;
                monke.right = monkeR;
            }

        }

        Console.WriteLine(monkeys["root"].Shout());
    }
}