namespace Expm.Core.Exceptions
{
    public class Guard
    {
        public static EntityGuard Entity { get =>  new EntityGuard(); }
    }

    public class EntityGuard {
        public void AgainstNull<T>(T obj, string parameter) where T : BaseEntity {
            if(obj is null) {
                throw new NoEntityException($"No entity exists, input parameter was: {parameter}");
            }
        }
    }
}