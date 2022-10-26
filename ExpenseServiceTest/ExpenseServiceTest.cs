using Expense.Service;
using Expense.Service.Exceptions;
using Expense.Service.Expense;
using Expense.Service.Projects;
using Xunit;

namespace Expense.Service.Test
{
    public class ExpenseServiceTest
    {
        [Fact]
        public void Should_return_internal_expense_type_if_project_is_internal()
        {
            // given
            Project project = new Project(ProjectType.INTERNAL, projectName:"Internal project");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(project);
            // then
            Assert.Equal(ExpenseType.INTERNAL_PROJECT_EXPENSE, expenseType);
        }

        [Fact]
        public void Should_return_expense_type_A_if_project_is_external_and_name_is_project_A()
        {
            // given
            Project projectA = new Project(ProjectType.EXTERNAL, projectName: "Project A");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(projectA);
            // then
            Assert.Equal(ExpenseType.EXPENSE_TYPE_A, expenseType);
        }

        [Fact]
        public void Should_return_expense_type_B_if_project_is_external_and_name_is_project_B()
        {
            // given
            Project projectB = new Project(ProjectType.EXTERNAL, projectName: "Project B");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(projectB);
            // then
            Assert.Equal(ExpenseType.EXPENSE_TYPE_B, expenseType);
        }

        [Fact]
        public void Should_return_other_expense_type_if_project_is_external_and_has_other_name()
        {
            // given
            Project projectB = new Project(ProjectType.EXTERNAL, projectName: "Project C");
            // when
            ExpenseType expenseType = ExpenseService.GetExpenseCodeByProjectTypeAndName(projectB);
            // then
            Assert.Equal(ExpenseType.OTHER_EXPENSE, expenseType);
        }

        [Fact]
        public void Should_throw_unexpected_project_exception_if_project_is_invalid()
        {
            // given
            Project projectB = new Project(ProjectType.UNEXPECTED_PROJECT_TYPE, projectName: "Project B");
            // when
            // then
            Assert.Throws<UnexpectedProjectTypeException>(() => ExpenseService.GetExpenseCodeByProjectTypeAndName(projectB));
        }
    }
}