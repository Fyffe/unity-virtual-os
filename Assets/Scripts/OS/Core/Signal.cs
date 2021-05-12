namespace OS.Core
{
	public abstract class Signal<T>
	{
		public readonly T Value;

		protected Signal(T value)
		{
			Value = value;
		}
	}
}
