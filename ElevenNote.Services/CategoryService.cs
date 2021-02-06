using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevenNote.Data;
using ElevenNote.Models;
namespace ElevenNote.Services
{
   public class CategoryService
    {
        public bool CreateCategory(CategoryCreate category)
        {
            var Entity = new Category
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(Entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Select(c => new CategoryListItem
                    {
                        Id = c.Id,
                        CategoryName = c.CategoryName
                    }).ToList();
                return query;
            }
        }

        public CategoryDetail GetCategoryById(int Id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var Category =
                    ctx
                    .Categories
                    .SingleOrDefault(c => c.Id == Id);

                return new CategoryDetail
                {
                    Id = Category.Id,
                    CategoryName = Category.CategoryName
                };
            }
        }

        public bool UpdateCategory(CategoryEdit categoryEdit)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var Category =
                    ctx
                    .Categories
                    .SingleOrDefault(c => c.Id == categoryEdit.Id);

                Category.CategoryName = categoryEdit.CategoryName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int Id)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var Category =
                   ctx
                   .Categories
                   .SingleOrDefault(c => c.Id == Id);

                ctx.Categories.Remove(Category);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
