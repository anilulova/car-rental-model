using System;
using System.Diagnostics.CodeAnalysis;

namespace Kursova.DomainModel.LookUps
{
    public class BrandInfo : IEquatable<BrandInfo>
    {
        public BrandInfo(string brand, string model)
        => (Brand, Model) = (brand, model);

        public string Brand { get; }
        public string Model { get; }

        public bool Equals([AllowNull] BrandInfo other)
        {
            if (other == null)
                return false;

            return this.Brand == other.Brand && this.Model == other.Model;
        }

        public override string ToString()
        {
            return $"Brand: {Brand}\n" +
                   $"Model: {Model}\n";
        }
    }
}