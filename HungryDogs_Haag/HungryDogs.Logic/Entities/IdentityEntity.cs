namespace HungryDogs.Logic.Entities
{
    public abstract class IdentityEntity : HungryDogs.Contracts.IIdentifiable
    {
        public int Id { get; set; }
    }
}
