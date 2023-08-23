using System;
using System.Collections.Generic;

namespace HW.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string LastName { get; set; } = null!; // 1. maddede OLACAK // Profilim linkine tıklandığında olacak

    public string FirstName { get; set; } = null!; // 1. maddede OLACAK// Profilim linkine tıklandığında olacak

    public string? Title { get; set; } // 1. maddede OLACAK // Profilim linkine tıklandığında olacak

    public string? TitleOfCourtesy { get; set; }

    public DateTime? BirthDate { get; set; } // Profilim linkine tıklandığında olacak

    public DateTime? HireDate { get; set; }

    public string? Address { get; set; } // Profilim linkine tıklandığında olacak

    public string? City { get; set; }

    public string? Region { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public string? HomePhone { get; set; } // Profilim linkine tıklandığında olacak

    public string? Extension { get; set; }

    public byte[]? Photo { get; set; }

    public string? Notes { get; set; }

    public int? ReportsTo { get; set; }

    public string? PhotoPath { get; set; }

    public virtual ICollection<Employee> InverseReportsToNavigation { get; set; } = new List<Employee>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Employee? ReportsToNavigation { get; set; }

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}
