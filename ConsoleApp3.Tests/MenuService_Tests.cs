using ConsoleApp3.Enums;
using ConsoleApp3.Interfaces;
using ConsoleApp3.Models.Responses;
using ConsoleApp3.Services;
using Moq;
using System;
using System.IO;
using Xunit;

namespace ConsoleApp3.Tests
{
    public class MenuService_Tests
    {
        [Fact]
        public void AddContactFromUserInput_ShouldHandleUserInputAndInteractWithContactBook()
        {
            // Arrange
            var mockContactBook = new Mock<IContactBook>();
            var menuService = new MenuService(mockContactBook.Object);

            // Ange testdata för Console.ReadLine
            var testInput = new StringReader("John\nDoe\n123456789\njohn@example.com\n123 Main St");
            Console.SetIn(testInput);

            // Act
            menuService.AddContactFromUserInput();

            // Assert
            mockContactBook.Verify(x => x.AddContact(It.IsAny<IContact>()), Times.Once);
        }

        [Fact]
        public void RemoveContact_ShouldPromptUserForEmailAndRemoveContact()
        {
            // Arrange
            var mockContactBook = new Mock<IContactBook>();
            var menuService = new MenuService(mockContactBook.Object);

            // Ange testdata för Console.ReadLine
            var testInput = new StringReader("test@example.com");
            Console.SetIn(testInput);

            // Anta att en kontakt med den angivna e-postadressen finns
            string userEmail = "test@example.com";
            mockContactBook.Setup(x => x.GetContactByEmail(userEmail)).Returns(new Contact());

            // Act
            menuService.RemoveContact();

            // Assert
            mockContactBook.Verify(x => x.GetContactByEmail(userEmail), Times.Once);
            mockContactBook.Verify(x => x.RemoveContactByEmail(userEmail), Times.Once);
        }

        [Fact]
        public void DisplayContactDetails_ShouldPromptUserForEmailAndDisplayDetails()
        {
            // Arrange
            var mockContactBook = new Mock<IContactBook>();
            var menuService = new MenuService(mockContactBook.Object);

            // Ange testdata för Console.ReadLine
            var testInput = new StringReader("test@example.com");
            Console.SetIn(testInput);

            // Anta att en kontakt med den angivna e-postadressen finns
            string userEmail = "test@example.com";
            mockContactBook.Setup(x => x.GetContactByEmail(userEmail)).Returns(new Contact());

            // Act
            menuService.DisplayContactDetails();

            // Assert
            mockContactBook.Verify(x => x.GetContactByEmail(userEmail), Times.Once);
        }
    }
}
