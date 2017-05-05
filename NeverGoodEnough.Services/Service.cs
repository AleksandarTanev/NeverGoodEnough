namespace NeverGoodEnough.Services
{
    using NeverGoodEnough.Data;
    using NeverGoodEnough.Data.Interfaces;

    public class Service
    {
        protected Service()
        {
            this.Context = new NeverGoodEnoughContext();
        }

        protected Service(INeverGoodEnoughContext context)
        {
            this.Context = context;
        }

        protected INeverGoodEnoughContext Context { get; }
    }
}
