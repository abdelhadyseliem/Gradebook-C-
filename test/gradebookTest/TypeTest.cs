using gradebook;
using Xunit;

namespace gradebookTest
{

    public delegate string WriteLogDelegate(string logMessage);


    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello");
            Assert.Equal(3, count);
        }

        string IncrementCount(string Message)
        {
            count++;
            return Message.ToLower();
        }

        string ReturnMessage(string Message)
        {
            count++;
            return Message;
        }

        [Fact]
        public void StringsBehavelikeValueTypes()
        {
            string name = "abdelhady";
            name = MakeUppercase(name);
            Assert.Equal("ABDELHADY", name);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(42, x);
        }

        private void SetInt(int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 42;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBooksetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBooksetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }


        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBooksetName(book1, "new Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBooksetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            setName(book1, "new Name");

            Assert.Equal("new Name", book1.Name);
        }

        private void setName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
