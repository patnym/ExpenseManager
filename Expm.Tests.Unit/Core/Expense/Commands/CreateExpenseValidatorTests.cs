using System.Collections.Generic;
using Expm.Core.Expense.Commands;
using FluentValidation;
using Xunit;

namespace Expm.Tests.Unit.Core.Expense.Commands
{
    public class CreateExpenseValidatorTests
    {
        private readonly IValidator<CreateExpenseCommand> _validator;

        public CreateExpenseValidatorTests()
        {
            _validator = new CreateExpenseValidator();
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void Can_Validate_Commands(CreateExpenseCommand cmd, bool isExpected)
        {
            //When
            var result = _validator.Validate(cmd);
            //Then
            Assert.True(result.IsValid == isExpected);
        }

        public static IEnumerable<object[]> GetData() {
            yield return new object[] {
                new CreateExpenseCommand {
                    Name = "Hello!"
                },
                true
            };

            yield return new object[] {
                new CreateExpenseCommand {
                    Name = null
                },
                false
            };

            yield return new object[] {
                new CreateExpenseCommand {
                    Name = ""
                },
                false
            };
        }
    }
}