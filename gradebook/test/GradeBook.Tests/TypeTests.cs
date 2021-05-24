using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Jim";
            string upper = MakeUppercase(name);

            Assert.Equal("Jim", name);
            Assert.Equal("JIM", upper);
        }

        private String MakeUppercase(string str) {
            return str.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue() 
        {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(3,x);
        }

        private int GetInt() {
            return 3;
        }

        private void SetInt(int x) {
            x = 4;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookRefSetName(ref book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookRefSetName(ref Book book, string name) {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name) {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name) {
            book.Name = name;
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1; // book2 points to book1's value
            
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
        }

        Book GetBook(string name) {
            
            return new Book(name);
        }
    }
}
