namespace Montesi.Utilities
{
    public interface IPausable
    {
        /// <summary>
        /// Set the pause status.
        /// </summary>
        public void PauseAll();
        
        /// <summary>
        /// Set the resume status.
        /// </summary>
        public void ResumeAll();
    }
}