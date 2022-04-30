namespace Montesi.Utilities
{
    /// <summary>
    /// Simulation of Optional from Java.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Optional<T> {
        private T _value;
        public bool IsPresent { get; private set; }

        private Optional() { }

        /// <summary>
        /// Creates an empty Optional object.
        /// </summary>
        /// <returns>An empty Optional</returns>
        public static Optional<T> Empty() => new Optional<T>();

        /// <summary>
        /// Creates an Optional of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The Optional of the value.</returns>
        public static Optional<T> Of(T value) {
            var obj = new Optional<T>();
            obj.Set(value);
            return obj;
        }
        
        private void Set(T value) {
            _value = value;
            IsPresent = true;
        }

        /// <returns>The value.</returns>
        public T Get() => _value;
    }

}