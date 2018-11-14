using System;
using System.Collections.Generic;
using Expm.Core.Expense.Commands.CreateExpenseEntry;
using FluentValidation;
using Xunit;

namespace Expm.Tests.Unit.Core.Expense.Commands.CreateExpenseEntry
{
    public class CreateExpenseEntryValidatorTests
    {
        private readonly IValidator<CreateExpenseEntryCommand> _validator;

        public CreateExpenseEntryValidatorTests()
        {
            _validator = new CreateExpenseEntryValidator();
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void Can_Validate_Commands(CreateExpenseEntryCommand cmd, bool shouldBeValid)
        {
            //When
            var result = _validator.Validate(cmd);

            //Then
            Assert.True(result.IsValid == shouldBeValid);
        }

        public static IEnumerable<object[]> GetData() {
            yield return new object[] {
                new CreateExpenseEntryCommand {
                    Name = "",
                    Description = "hello",
                    Cost = 10,
                    Date = DateTime.UtcNow
                },
                false
            };

            yield return new object[] {
                new CreateExpenseEntryCommand {
                    Name = "Hello",
                    Cost = 10,
                    Date = DateTime.UtcNow
                },
                true
            };

            yield return new object[] {
                new CreateExpenseEntryCommand {
                    Name = "dasdads",
                    Description = "hello",
                    Cost = 10,
                    Date = DateTime.UtcNow
                },
                true
            };
            
            yield return new object[] {
                new CreateExpenseEntryCommand {
                    Name = "Hello",
                    Description = "hello",
                    Cost = 0,
                    Date = DateTime.UtcNow
                },
                false
            };

            yield return new object[] {
                new CreateExpenseEntryCommand {
                    Name = "Hi",
                    Description = "hello",
                    Cost = 10
                },
                false
            };
        }
    }
}