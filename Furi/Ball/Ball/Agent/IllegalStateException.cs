namespace Ball.Agent;

public class IllegalStateException : Exception
{
    public string GetMessage()
    {
        return "cannot duplicate Grandchild ball";
    }
}