using System.Threading;

namespace Montesi.Utilities
{
    /// <summary>
    /// Class that make the Thread class extendable.
    /// </summary>
    public abstract class BaseThread
    {
        private readonly Thread _thread;

        /// <summary>
        /// Constructor that creates the Thread.
        /// </summary>
        protected BaseThread()
        {
            _thread = new Thread(RunThread);
        }

        /// <summary>
        /// Thread methods / properties
        /// </summary>
        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public bool IsAlive => _thread.IsAlive;

        /// <summary>
        /// To override in the desired class.
        /// </summary>
        protected abstract void RunThread();
    }
}