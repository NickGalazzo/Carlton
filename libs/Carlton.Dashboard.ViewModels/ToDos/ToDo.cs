﻿using System;

namespace Carlton.Dashboard.ViewModels.ToDos
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime ExpirationDate { get; set; }

        public ToDo(int id, string name, bool isCompleted)
            : this(id, name, isCompleted, DateTime.Today.AddDays(7))
        {
        }

        public ToDo(int id, string name, bool isCompleted, DateTime expirationDate)
        {
            Id = id;
            Name = name;
            IsCompleted = isCompleted;
            ExpirationDate = expirationDate;
        }

        public ToDo()
        {

        }
    }
}
