using System;
using System.Collections.Generic;
using Repo;

namespace Tests.Methods
{
    public static class FakeDBSeeder
    {
        public static AppUser[] SeedUsers => new AppUser[]
        {
            new AppUser()
            {
                Id = "AFW062422G3C",
                Email = "test1@example.com",
                FirstName = "Test",
                LastName = "McTest",
                VerificationCode = "T2D5GE",
                PasswordHash = "$2a$11$OQlr6mGOKrX8BWsYdBkM7OUu5AjIRkezNTKU.7DuFrC6HOk4/7pz6"
            },
            new AppUser()
            {
                Id = "AFW062422DV1",
                Email = "test2@example.com",
                FirstName = "Test",
                LastName = "McTest",
                VerificationCode = "S2HY3D",
                PasswordHash = "$2a$11$OQlr6mGOKrX8BWsYdBkM7OUu5AjIRkezNTKU.7DuFrC6HOk4/7pz6"
            },
            new AppUser()
            {
                Id = "AFW062522AH2",
                Email = "test3@example.com",
                FirstName = "Test",
                LastName = "McTest",
                VerificationCode = "N7GE61",
                PasswordHash = "$2a$11$OQlr6mGOKrX8BWsYdBkM7OUu5AjIRkezNTKU.7DuFrC6HOk4/7pz6"
            }
        };
    }
}
