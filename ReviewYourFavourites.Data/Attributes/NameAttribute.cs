namespace ReviewYourFavourites.Data.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class NameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var name = value as string;

            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            if (name.Split().ToList().Any(x => x.Equals(string.Empty)))
            {
                return false;
            }

            return true;
        }
    }
}
