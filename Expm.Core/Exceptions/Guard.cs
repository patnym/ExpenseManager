namespace Expm.Core.Exceptions
{
    public static class Guard
    {
        public static void AgainstNull(object obj, string msg) {
            if(obj is null) {
                throw new NoEntityException(msg);
            }
        }
    }
}