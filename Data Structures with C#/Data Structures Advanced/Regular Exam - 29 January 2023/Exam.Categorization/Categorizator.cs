using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Categorization
{
    public class Categorizator : ICategorizator
    {
        private Dictionary<string, Category> categories;

        public Categorizator()
        {
            this.categories = new Dictionary<string, Category>();
        }

        public void AddCategory(Category category)
        {
            if (this.categories.ContainsKey(category.Id))
            {
                throw new ArgumentException();
            }

            this.categories.Add(category.Id, category);
        }

        public void AssignParent(string childCategoryId, string parentCategoryId)
        {
            if (!this.categories.ContainsKey(childCategoryId) || !this.categories.ContainsKey(parentCategoryId))
            {
                throw new ArgumentException();
            }

            var child = this.categories[childCategoryId];
            var parent = this.categories[parentCategoryId];

            if (parent.Children.Contains(child))
            {
                throw new ArgumentException();
            }

            child.Parent = parent;
            parent.Children.Add(child);


            //var root = parent;

            //while (root.Parent != null)
            //{
            //    root = root.Parent;
            //}

            //this.UpdateDepth(root);

            while (parent != null)
            {
                parent.Depth = Math.Max(parent.Depth, child.Depth + 1);
                child = parent;
                parent = parent.Parent;
            }
        }

        public bool Contains(Category category)
        {
            return this.categories.ContainsKey(category.Id);
        }

        public IEnumerable<Category> GetChildren(string categoryId)
        {
            if (!this.categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            var category = this.categories[categoryId];

            var children = new HashSet<Category>();
            this.GetChildren(category, children);

            return children;

        }

        private void GetChildren(Category category, HashSet<Category> children)
        {
            foreach (var child in category.Children)
            {
                children.Add(child);
                GetChildren(child, children);
            }
        }

        public IEnumerable<Category> GetHierarchy(string categoryId)
        {
            if (!this.categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            var category = this.categories[categoryId];
            var hierarchy = new Stack<Category>();

            //this.GetHierarchy(category, hierarchy);

            hierarchy.Push(category);

            while (category.Parent != null)
            {
                hierarchy.Push(category.Parent);
                category = category.Parent;
            }

            return hierarchy;
        }

        private void GetHierarchy(Category category, Stack<Category> hierarchy)
        {
            if (category == null)
            {
                return;
            }

            hierarchy.Push(category);
            this.GetHierarchy(category.Parent, hierarchy);
        }

        public IEnumerable<Category> GetTop3CategoriesOrderedByDepthOfChildrenThenByName()
        {
            return this.categories.Values
                 .OrderByDescending(c => c.Depth)
                 .ThenBy(c => c.Name)
                 .Take(3);

        }

        private int UpdateDepth(Category category)
        {
            if (category == null)
            {
                return 0;
            }
            int depth = 0;

            foreach (var child in category.Children)
            {
                depth = Math.Max(depth, UpdateDepth(child));
            }

            category.Depth = depth + 1;

            return category.Depth;
        }

        public void RemoveCategory(string categoryId)
        {
            if (!this.categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            var category = this.categories[categoryId];
            this.categories.Remove(categoryId);

            this.RemoveChildren(category);

            if (category.Parent != null)
            {
                category.Parent.Children.Remove(category);
            }
        }

        private void RemoveChildren(Category category)
        {

            foreach (var child in category.Children)
            {
                this.RemoveChildren(child);
                this.categories.Remove(child.Id);
            }
        }

        public int Size()
        {
            return this.categories.Count;
        }
    }
}
