﻿using System.Collections.Generic;

namespace Exam.Categorization
{
    public class Category
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Category Parent { get; set; }

        public HashSet<Category> Children = new HashSet<Category>();

        public int Depth { get; set; }

        public Category(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
