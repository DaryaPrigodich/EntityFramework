using DatabaseInteraction.Fakers;
using DatabaseInteraction.Models.HumanResources;
using NUnit.Framework;

namespace DatabaseInteraction.Tests;

public class DepartmentInteractionTests : BaseTest
{
    private Department _department = null!;
    
    [Test]
    public void GetDepartmentById()
    {
        const int departmentId = 3;
        
        _department = DepartmentService.GetDepartmentById(departmentId);
        
        Assert.That(_department.DepartmentId, Is.EqualTo(departmentId));
    }

    [Test]
    public void CreatDepartmentRow()
    {
        var departmentToAdd = new DepartmentFaker().Generate();
        
         DepartmentService.CreateDepartment(departmentToAdd);
         
         _department = DepartmentService.GetDepartmentByName(departmentToAdd.Name!);
         
         Assert.That(departmentToAdd.Name, Is.EqualTo(_department.Name));
    }

    [Test]
    public void DeleteDepartmentRow()
    {
        var createdDepartment = new DepartmentFaker().Generate();
        
        DepartmentService.CreateDepartment(createdDepartment);

        var removedDepartment = DepartmentService.DeleteDepartmentRow(createdDepartment);
        
        Assert.That(removedDepartment, Is.Null);
    }

    [Test]
    public void UpdateDepartmentGroupName()
    {
        const string groupNameToUpdate = "Updated name";
        var createdDepartment = new DepartmentFaker().Generate();

        DepartmentService.CreateDepartment(createdDepartment);

        var updatedDepartment = DepartmentService.UpdateDepartmentGroupName(createdDepartment, groupNameToUpdate);
        
        Console.Out.WriteLine(updatedDepartment?.GroupName);
       
        Assert.That(updatedDepartment?.GroupName, Is.EqualTo(groupNameToUpdate));
    }

    [Test]
    public void CheckDepartmentsAmount()
    {
        var departmentsBeforeCreating = DepartmentService.GetDepartmentsAmount();
        
        var departmentToAdd = new DepartmentFaker().Generate();
        
        DepartmentService.CreateDepartment(departmentToAdd);
        
        var departmentsAfterCreating = DepartmentService.GetDepartmentsAmount();
        
        Assert.That(departmentsBeforeCreating + 1, Is.EqualTo(departmentsAfterCreating));
    }

    [Test]
    public void GetDepartmentsWithParticularDateTime()
    {
        var departmentToAdd = new DepartmentFaker().Generate();
        departmentToAdd.ModifiedDate = DateTime.Today;
        
        DepartmentService.CreateDepartment(departmentToAdd);
        
        var departmentsList = DepartmentService.GetDepartmentsAccordingDate(DateTime.Today);
        
        Assert.That(departmentsList, Is.Not.Empty);
    }
    
    [Test]
    public void GetDepartmentsWithParticularName()
    {
        const string nameStartsWith = "a";
        
        var departmentsList = DepartmentService.GetDepartmentsWhereNameStartsWithLetter(nameStartsWith);
        
        Assert.That(departmentsList, Is.Not.Empty);
    }
}