using FakeItEasy;
using QuizApi.Controllers;
using QuizApi.Models;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace QuizApi.Tests
{
    public class QuizItemControllerTests
    {
        private QuizDbContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<QuizDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var context = new QuizDbContext(options);

            var answer0 = new Answer { Id = 3, Content = "Dải yếm", QuestionId = 0 };
            var answer1 = new Answer { Id = 4, Content = "Miếng lụa", QuestionId = 0 };
            var answer2 = new Answer { Id = 5, Content = "Chiếc khăn hồng", QuestionId = 0 };

            List<Answer> Answers = new List<Answer>();
            Answers.Add(answer0);
            Answers.Add(answer1);
            Answers.Add(answer2);

            var quizItem = new QuizItem { Id = 0, Question = "Khi gặp Thúy Kiều , Kim Trọng trao cho vật gì làm tin?", Answers = Answers, RightAnswer = 2 };

            context.Add(quizItem);
            context.SaveChangesAsync();
            return context;
        }

        [Fact]
        public async Task GetQuizItems_Returns_Correct_Number_Of_QuizItem()
        {
            // Arrange
            var context = GetContextWithData();

            var controller = new QuizItemController(context);

            // Act
            var result = await controller.GetQuizItems();

            // Assert
            IEnumerable<QuizItem>? quizItems = result.Value as IEnumerable<QuizItem>;
            Assert.Single(quizItems);
        }

        [Fact]
        public async Task GetQuizItemById_Returns_QuizItem()
        {
            // Arrange
            var context = GetContextWithData();

            var controller = new QuizItemController(context);

            // Act
            var result = await controller.GetQuizItem(0);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateQuizItem_Returns_QuizItem()
        {
            // Arrange
            var context = GetContextWithData();

            var answer0 = new Answer { Id = 6, Content = "Điệu nhảy Hula", QuestionId = 2 };
            var answer1 = new Answer { Id = 7, Content = "Điệu nhảy Cha cha cha", QuestionId = 2 };
            var answer2 = new Answer { Id = 8, Content = "Điệu nhảy Tango", QuestionId = 2 };

            List<Answer> Answers = new List<Answer>();
            Answers.Add(answer0);
            Answers.Add(answer1);
            Answers.Add(answer2);

            var quizItem = new QuizItem { Id = 2, Question = "Vũ điệu truyền thống của đảo Hawaii là?", Answers = Answers, RightAnswer = 0 };

            var controller = new QuizItemController(context);

            // Act
            var result = await controller.CreateQuizItem(quizItem);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteQuizItemById_Succeeds()
        {
            // Arrange
            var context = GetContextWithData();

            var controller = new QuizItemController(context);

            // Act
            var result = await controller.DeleteQuizItem(1);

            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateQuizItemsById_Requests_Unmatch_Id()
        {
            // Arrange
            var context = GetContextWithData();

            var controller = new QuizItemController(context);

            //var answer0 = new Answer { Id = 6, Content = "Điệu nhảy Hula", QuestionId = 2 };
            //var answer1 = new Answer { Id = 7, Content = "Điệu nhảy Cha cha cha", QuestionId = 2 };
            //var answer2 = new Answer { Id = 8, Content = "Điệu nhảy Tango", QuestionId = 2 };

            //List<Answer> Answers = new List<Answer>();
            //Answers.Add(answer0);
            //Answers.Add(answer1);
            //Answers.Add(answer2);

            //var quizItem = new QuizItem { Id = 2, Question = "Vũ điệu truyền thống của đảo Hawaii là?", Answers = Answers, RightAnswer = 0 };

            // Act
            var result = await controller.UpdateQuizItem(1, new QuizItem());

            // Assert
            result.Should().BeOfType<Microsoft.AspNetCore.Mvc.BadRequestResult>();
        }
    }
}