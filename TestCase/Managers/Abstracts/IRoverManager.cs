using TestCase.Models;

namespace TestCase.Managers.Abstracts
{
    public interface IRoverManager
    {
        Rover[,] Plateau { get; set; }
        void ChangePosition(int x, int y, char[] path);
        void PrepareEnvironment();
    }
}
