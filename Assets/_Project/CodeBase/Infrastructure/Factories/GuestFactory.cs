using _Project.CodeBase.Infrastructure.Services.PersistentProgress;

namespace _Project.CodeBase.Infrastructure.Factories
{
    public class GuestFactory
    {
        private readonly ISavedProgress _progress;

        public GuestFactory(ISavedProgress progress)
        {
            _progress = progress;
        }
    }
}