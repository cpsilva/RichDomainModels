using RichDomainModels.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain
{
    public class Product : Entity, IAggregateRoot
    {
        public Guid CategoryId { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Price { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public string Image { get; private set; }
        public int QuantityStock { get; private set; }
        public Category Category { get; private set; }

        public Product(string name, string description, bool active, decimal price, Guid categoryId, DateTime registrationDate, string image)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Active = active;
            Price = price;
            RegistrationDate = registrationDate;
            Image = image;
        }

        public void Activate() => Active = true;
        public void Deactivate() => Active = true;

        public void UpdateCategory(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void UpdateDescription(string productDescription) => Description = productDescription;

        public void RemoveFromStock(int quantity)
        {
            if (quantity < 0) quantity *= -1;

            QuantityStock -= quantity;
        }

        public void RefillStock(int quantity)
        {
            QuantityStock += quantity;
        }

        public bool HasStock(int quantity)
        {
            return QuantityStock >= quantity;
        }

        public void Validate()
        {

        }
    }

    public class Category : Entity
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public Category(string name, int code)
        {
            Name = name;
            Code = code;
        }

        public override string ToString()
        {
            return $"{Name} - {Code}";
        }
    }
}
