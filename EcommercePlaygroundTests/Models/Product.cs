using System.Reflection;
using System.Text;

namespace EcommercePlaygroundTests.Models
{
    public class Product : IEquatable<Product?>
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; internal set; }
        public decimal Price { get; internal set; }
        public string? Model { get; internal set; }
        public string? Brand { get; internal set; }
        public string? Availability { get; internal set; }
        public string? Summary { get; internal set; }
        public string? Weight { get; internal set; }
        public string? Dimensions { get; internal set; }
        public string CompareImage { get; internal set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Product);
        }

        public bool Equals(Product? other)
        {
            return other is not null &&
                   Id == other.Id &&
                   Name == other.Name &&
                   Image == other.Image &&
                   Price == other.Price &&
                   Model == other.Model &&
                   Brand == other.Brand &&
                   Availability == other.Availability &&
                   Summary == other.Summary &&
                   Weight == other.Weight &&
                   Dimensions == other.Dimensions &&
                   CompareImage == other.CompareImage;

        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Name);
            hash.Add(Image);
            hash.Add(Price);
            hash.Add(Model);
            hash.Add(Brand);
            hash.Add(Availability);
            hash.Add(Summary);
            hash.Add(Weight);
            hash.Add(Dimensions);
            hash.Add(CompareImage);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Type type = this.GetType();
            PropertyInfo[] props = type.GetProperties();

            foreach (var prop in props)
            {
                object value = prop.GetValue(this, null);
                sb.AppendLine($"{prop.Name}: {value}");
            }

            return sb.ToString();
        }

        public static bool operator ==(Product? left, Product? right)
        {
            return EqualityComparer<Product>.Default.Equals(left, right);
        }

        public static bool operator !=(Product? left, Product? right)
        {
            return !(left == right);
        }
    }
}
