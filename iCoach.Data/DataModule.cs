using Ninject.Modules;
using Ninject.Web.Common;
using iCoach.Data.EF;

namespace iCoach.Data
{
    public class DataModule: NinjectModule
    {
        public override void Load()
        {
            Bind<ICoachDb>().To<CoachDbContext>().InRequestScope();
        }
    }
}
