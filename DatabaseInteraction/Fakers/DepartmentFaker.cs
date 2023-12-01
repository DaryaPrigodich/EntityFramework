using Bogus;
using DatabaseInteraction.Models.HumanResources;

namespace DatabaseInteraction.Fakers;

public class DepartmentFaker : Faker<Department>
{
    public DepartmentFaker()
    {
        RuleFor(d => d.GroupName, f => f.Lorem.Word());
        RuleFor(d => d.Name, f => f.Lorem.Word());
        RuleFor(d => d.ModifiedDate, f => f.Date.Future());
    }
}