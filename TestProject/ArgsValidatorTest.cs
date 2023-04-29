namespace TestProject
{
    public class ArgsValidatorTest
    {
        private readonly Fixture _fixture = new();
        private readonly string _validPath = Path.Combine(Environment.CurrentDirectory, "Pool202301.json");

        [Fact]
        public void GivenEmptyArgs_ShouldReturnNotValidAndEmptyArgsErrorMessage()
        {
            var expectedMessages = new List<string> { ArgsValidator.PasDeuxArguments() };

            var result = ArgsValidator.Validate(Array.Empty<string>());

            result.IsValid().Should().BeFalse();
            result.Messages.Should().BeEquivalentTo(expectedMessages);
        }

        [Fact]
        public void GivenJustOneArgs_ShouldReturnNotValidAndEmptyArgsErrorMessage()
        {
            var args = new string[] { _fixture.Create<string>() };
            var expectedMessages = new List<string> { ArgsValidator.PasDeuxArguments() };

            var result = ArgsValidator.Validate(args);

            result.IsValid().Should().BeFalse();
            result.Messages.Should().BeEquivalentTo(expectedMessages);
        }

        [Fact]
        public void GivenThreeArgs_ShouldReturnNotValidAndEmptyArgsErrorMessage()
        {
            var args = _fixture.CreateMany<string>(3).ToArray();
            var expectedMessages = new List<string> { ArgsValidator.PasDeuxArguments() };

            var result = ArgsValidator.Validate(args);

            result.IsValid().Should().BeFalse();
            result.Messages.Should().BeEquivalentTo(expectedMessages);
        }

        [Fact]
        public void GivenEmptyFirstParameter_ShoudlReturnNotValidAndErrorMessageParam1()
        {
            var args = new string[] { " ", "1" };
            var expectedMessages = new List<string> { ArgsValidator.MessageErreurParam1() };

            var result = ArgsValidator.Validate(args);

            result.IsValid().Should().BeFalse();
            result.Messages.Should().BeEquivalentTo(expectedMessages);
        }

        [Fact]
        public void GivenNotExistingFileFirstParameter_ShoudlReturnNotValidAndErrorMessageParam1()
        {
            var nonExistingFile = Path.Combine(Environment.CurrentDirectory, $"{Guid.NewGuid()}.txt");
            var args = new string[] { nonExistingFile, "1" };
            var expectedMessages = new List<string> { ArgsValidator.MessageErreurParam1() };

            var result = ArgsValidator.Validate(args);

            result.IsValid().Should().BeFalse();
            result.Messages.Should().BeEquivalentTo(expectedMessages);
        }

        [Fact]
        public void GivenNotJsonFileFirstParameter_ShoudlReturnNotValidAndErrorMessageParam1()
        {
            var nonExistingFile = Path.Combine(Environment.CurrentDirectory, "202301.html");
            var args = new string[] { nonExistingFile, "1" };
            var expectedMessages = new List<string> { ArgsValidator.MessageErreurParam1() };

            var result = ArgsValidator.Validate(args);

            result.IsValid().Should().BeFalse();
            result.Messages.Should().BeEquivalentTo(expectedMessages);
        }

        [Fact]
        public void GivenJsonNotInGoodFormatFirstParameter_ShoudlReturnNotValidAndErrorMessageParam1()
        {
            var nonExistingFile = Path.Combine(Environment.CurrentDirectory, "InvalidFormat.json");
            var args = new string[] { nonExistingFile, "1" };
            var expectedMessages = new List<string> { ArgsValidator.MessageErreurParam1() };

            var result = ArgsValidator.Validate(args);

            result.IsValid().Should().BeFalse();
            result.Messages.Should().BeEquivalentTo(expectedMessages);
        }

        [Fact]
        public void GivenEmptySecondParameter_ShoudlReturnNotValidAndErrorMessageParam2()
        {
            var args = new string[] { _validPath, "  " };
            var expectedMessages = new List<string> { ArgsValidator.MessageErreurParam2() };

            var result = ArgsValidator.Validate(args);

            result.IsValid().Should().BeFalse();
            result.Messages.Should().BeEquivalentTo(expectedMessages);
        }

        [Fact]
        public void GivenTextSecondParameter_ShoudlReturnNotValidAndErrorMessageParam2()
        {
            var args = new string[] { _validPath, _fixture.Create<string>() };
            var expectedMessages = new List<string> { ArgsValidator.MessageErreurParam2() };

            var result = ArgsValidator.Validate(args);

            result.IsValid().Should().BeFalse();
            result.Messages.Should().BeEquivalentTo(expectedMessages);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("16")]
        public void GivenTooSmallOrBigSecondParameter_ShoudlReturnNotValidAndErrorMessageParam2(string param2)
        {
            var args = new string[] { _validPath, param2 };
            var expectedMessages = new List<string> { ArgsValidator.MessageErreurParam2() };

            var result = ArgsValidator.Validate(args);

            result.IsValid().Should().BeFalse();
            result.Messages.Should().BeEquivalentTo(expectedMessages);
        }

        [Fact]
        public void GivenValidParameters_ShoudlReturnIsValidAndNoMessages()
        {
            var args = new string[] { _validPath, "4" };

            var result = ArgsValidator.Validate(args);

            result.IsValid().Should().BeTrue();
            result.Messages.Should().BeEmpty();
        }
    }
}
