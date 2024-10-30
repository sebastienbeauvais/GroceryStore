
namespace GroceryStoreUnitTest.HelperClasses
{
    public class ConsoleInput : IDisposable
    {
        private readonly System.IO.StringReader _stringReader;
        private readonly System.IO.TextReader _originalInput;

        public ConsoleInput(params string[] inputs)
        {
            _stringReader = new System.IO.StringReader(string.Join(Environment.NewLine, inputs));
            _originalInput = Console.In;
            Console.SetIn(_stringReader);
        }

        public void Dispose()
        {
            Console.SetIn(_originalInput);
            _stringReader.Dispose();
        }
    }
}

