﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace APITest.Domain;

public partial class UserMaster
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Role { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }
}