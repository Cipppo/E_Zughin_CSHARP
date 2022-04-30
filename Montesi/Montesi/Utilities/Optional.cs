namespace Montesi.Utilities
{
    public class Optional<T> {
        private T _value;
        public bool IsPresent { get; private set; } = false;

        private Optional() { }

        public static Optional<T> Empty() => new Optional<T>();

        public static Optional<T> Of(T value) {
            var obj = new Optional<T>();
            obj.Set(value);
            return obj;
        }

        private void Set(T value) {
            _value = value;
            IsPresent = true;
        }

        public T Get() => _value;
    }

}