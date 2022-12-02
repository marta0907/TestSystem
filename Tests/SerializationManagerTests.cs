using BLL.Interfaces;
using BLL.Managers;
using DAL.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace BLL.Tests
{
    public class SerializationManagerTests 
    {
        private ISerializationManager<Test> service = new JsonSerializationManager<Test>();
        [Fact]
        public void Serialize_NullArgument_ReturnsNull()
        {
            //assert
            Assert.Equal(@"{}",service.Serialize(null));
        }

        
        [Fact]
        public void Serialize_NotNullArgument_ReturnsString()
        {
            //arrange
            Test test = InitData();
            //act
            var result = service.Serialize( test);
            //assert
            Assert.NotNull(result);
            Assert.IsType<String>(result);
        }
        
        [Fact]
        public void Deserialize_NullArgument_ReturnsNull()
        {
            //assert
            Assert.Null(service.Deserialize(null));
        }

        [Fact]
        public void Deserialize_ArgumentIsNotJson_ReturnsNull()
        {
            //assert
             Assert.Null(service.Deserialize("s sj ,"));
        }

        [Fact]
        public void Deserialize_NotValidJson_ReturnsNull()
        {
            //assert
            Assert.Null(service.Deserialize(@"{}"));
        }


        [Fact]
        public void SerializeDeserialize__ReturnsTheSameTest()
        {
            //arrange
            Test test = InitData();
            //act
            var str = service.Serialize( test );
            var result = service.Deserialize(str);
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
