

namespace Kursova.DomainModel.LookUps
{
    public class Extra
    {
        public Extra(string extraType) => (ExtraType) = (extraType);

        public string ExtraType { get; set; }

        public override string ToString()
        {
            return $"Extra type: {ExtraType}";
        }

    }
}
