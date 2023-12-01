using DatabaseInteraction.Services;
using NUnit.Framework;

namespace DatabaseInteraction.Tests;

public class BaseTest
{
    protected SqlDepartmentService DepartmentService = null!;

    [SetUp]
    public void SetUpSqlService()
    {
        DepartmentService = new SqlDepartmentService();
    }
}
