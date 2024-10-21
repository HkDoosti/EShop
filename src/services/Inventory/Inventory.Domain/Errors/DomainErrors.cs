using Inventory.Domain.Shared;

namespace Inventory.Domain.Errors;

public static class DomainErrors
{
    public static class CategoryErrors
    {
        public static readonly Func<int, Error> NotFound = id => new Error(
            "Category.NotFound",
            $"The Category with the identifier {id} was not found.");

        public static readonly Error ParentIdCanNotBeZero = new Error(
            "Category.ParentIdCanNotBeZero",
            $"ParentId cannot be zero.");

        public static readonly Error TitleCanNotBeNull = new Error(
            "Category.TitleCanNotBeNull",
            $"Title cannot be null.");

        public static readonly Error TitleCanNotBeEmpty = new Error(
            "Category.TitleCanNotBeEmpty",
            $"Title cannot be Empty.");

        public static readonly Error TitleInvalidLength = new Error(
            "Category.TitleInvalidLength",
            $"Category Title must be between 1 and 100 characters.");

        public static readonly Error DescriptionInvalidLength = new Error(
            "Category.DescriptionInvalidLength",
            $"Category Description must have less than 2000 characters.");
    }
}
