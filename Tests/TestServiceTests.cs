using BLL.Interfaces;
using BLL.Services;
using DAL.Entities;
using DAL.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests
{
    public class TestServiceTests
    {
        private readonly Mock<IFileSystemManager> _fileMock;
        private readonly Mock<ISerializationManager<Test>> _jsonMock;
        private readonly Mock<IUnitOfWork> _unit;
        private readonly TestService _testService;

        public TestServiceTests()
        {
            _fileMock = new Mock<IFileSystemManager>();
            _jsonMock = new Mock<ISerializationManager<Test>>();
            _unit = new Mock<IUnitOfWork>();
            _testService = new TestService(_jsonMock.Object, _fileMock.Object,_unit.Object);
        }

        [Fact]
        public async Task TestServise_LoadFromFileAsync_ReturnsCorrectTest()
        {
            //arrange
            string path = "path";
            Test test = InitData();
   
            _fileMock.Setup(x => x.ReadFromFileAsync(null)).ReturnsAsync("json");
            _jsonMock.Setup(x => x.Deserialize("json")).Returns(test);
            //act
            var result = await _testService.LoadTestFromFileSystem(path);

            //assert
            Assert.Equal(test.Id, result.Id);
            Assert.Equal(test.Title, result.Title);
            Assert.Equal(test.Author, result.Author);
            Assert.Equal(test.InfoForTaker, result.InfoForTaker);
            Assert.Equal(test.Description, result.Description);
            Assert.Equal(test.MinPassPercentage, result.MinPassPercentage);
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(test.Questions[i].QuestionText, result.Questions[i].QuestionText);
                for (int j = 0; j < 5; j++)
                {
                    Assert.Equal(test.Questions[i].Answers[j].AnswerText,
                                    result.Questions[i].Answers[j].AnswerText);
                    Assert.Equal(test.Questions[i].Answers[j].IsTrue,
                                    result.Questions[i].Answers[j].IsTrue);
                }
            }

        }

        [Fact]
        public async Task TestServise_WriteToFileAsync_Writes()
        {
            Test test = InitData();
            string json = @"{}";

          
            _fileMock.Setup(x => x.WriteToFileAsync(json,null)).ReturnsAsync(true);
            _jsonMock.Setup(x => x.Serialize(test)).Returns(json);
            //act
            var result = await _testService.SaveTestToFileSystem(test);

            //assert
            Assert.True(result);
            
        }

        private Test InitData()
        {
            Test test = new Test();
            test.Author = "author";
            test.Description = "description";
            test.InfoForTaker = "info";
            test.Title = "name";
            test.Questions = new List<Question>();
            for (int i = 0; i < 5; i++)
            {
                Question block = new Question();
                block.Answers = new List<Answer>();
                block.QuestionText = $"question {i}";
                for (int j = 0; j < 5; j++)
                {
                    Answer answer = new Answer();
                    answer.AnswerText = $"answer{i}{j}";
                    answer.IsTrue = j == i;
                    block.Answers.Add(answer);
                };
                test.Questions.Add(block);
            }
            return test;
        }
    }
}
