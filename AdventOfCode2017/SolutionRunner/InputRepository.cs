using System.Configuration;

namespace SolutionRunner
{
    public static class InputRepository
    {
        public static string GetDay01Input()
        {
            return ConfigurationManager.AppSettings["inputDay01"];
        }
    }
}
