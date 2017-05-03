namespace NeverGoodEnough.Services
{
    using NeverGoodEnough.Data;

    public class Service
    {
        private NeverGoodEnoughContext context;

        protected Service()
        {
            this.context = new NeverGoodEnoughContext();
        }

        protected NeverGoodEnoughContext Context
        {
            get { return this.context; }
        }
    }
}
