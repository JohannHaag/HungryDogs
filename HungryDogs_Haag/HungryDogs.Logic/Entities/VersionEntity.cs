using HungryDogs.Contracts;

namespace HungryDogs.Logic.Entities
{
    public abstract class VersionEntity : IdentityEntity, HungryDogs.Contracts.IVersionable
    {
        public byte[] RowVersion { get; set; }
    }
}
