using System.Threading;

namespace Montesi.Utilities
{
    public abstract class BaseThread
    {
        private readonly Thread _thread;

        protected BaseThread()
        {
            _thread = new Thread(RunThread);
        }

        // Thread methods / properties
        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public bool IsAlive => _thread.IsAlive;

        // Override in base class
        protected abstract void RunThread();
    }
}