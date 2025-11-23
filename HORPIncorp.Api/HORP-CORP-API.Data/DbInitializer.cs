using HORPIncorp.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace HORP_CORP_API.Data
{
 public static class DbInitializer
 {
 public static void Initialize(ModelBuilder builder)
 {
 // Seed initial catalog items
 builder.Entity<Item>().HasData(
 new Item("Shirt", "Ohio State shirt", "Nike",29.99M, "/images/shirt.jpg") { Id =1 },
 new Item("Shorts", "Ohio State shorts", "Nike",44.99M, "/images/shorts.jpg") { Id =2 }
 );
 }
 }
}
