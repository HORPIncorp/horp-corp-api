using HORPIncorp.Domain.Catalog;

namespace HORPIncorp.Domain.Tests;

[TestClass]
public sealed class ItemTests
{
    [TestMethod]
    public void Can_Create_New_Item()
    {
        var item = new Item("Name", "Description", "Brand", 10.00m, "/images/test.jpg");

        Assert.AreEqual("Name", item.Name);
        Assert.AreEqual("Description", item.Description);
        Assert.AreEqual("Brand", item.Brand);
        Assert.AreEqual(10.00m, item.Price);
        Assert.AreEqual("/images/test.jpg", item.ImageUrl);
    }
    [TestMethod]
    public void Can_Create_Add_Rating()
    {
        //Arrange
        var item = new Item("Name", "Description", "Brand", 10.00m, "/images/test.jpg");
        var rating = new Rating(5, "Name", "Review");

        //Act
        item.AddRating(rating);

        //Assert
        Assert.AreEqual(rating, item.Ratings[0]);
    }
}
