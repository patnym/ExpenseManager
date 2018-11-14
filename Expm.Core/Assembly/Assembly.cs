using System.Reflection;

namespace Expm.Core
{
    public static class Project
    {
        public static Assembly Assembly =>
                typeof(Project).Assembly;
    }
}