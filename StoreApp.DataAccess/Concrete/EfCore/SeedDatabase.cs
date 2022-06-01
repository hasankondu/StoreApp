using Microsoft.EntityFrameworkCore;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApp.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new StoreContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count()==0)
                {
                    context.Categories.AddRange(Categories);
                }

                if (context.CategorySubs.Count() == 0)
                {
                    context.CategorySubs.AddRange(CategorySubs);
                }

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategories);
                }

                if (context.Advertiseds.Count() == 0)
                {
                    context.Advertiseds.AddRange(Advertiseds);
                }
                context.SaveChanges();
            }
        }
        private static Category[] Categories = {
            new Category() {CategoryName="KADIN"},
            new Category() {CategoryName="ERKEK"},
            new Category() {CategoryName="ÇOCUK"},
            new Category() {CategoryName="EV & YAŞAM"},
            new Category() {CategoryName="SÜPERMARKET"},
            new Category() {CategoryName="KOZMETİK"},
            new Category() {CategoryName="AYAKKABI & ÇANTA"},
            new Category() {CategoryName="SAAT & AKSESUAR"},
            new Category() {CategoryName="ELEKTRONİK"}
        };


        private static CategorySub[] CategorySubs = {
            new CategorySub() {CategorySubName="Elbise", Category=Categories[0]},
            new CategorySub() {CategorySubName="Sweatshirt", Category=Categories[0]},
            new CategorySub() {CategorySubName="Kazak & Hırka", Category=Categories[0]},
            new CategorySub() {CategorySubName="T-shirt", Category=Categories[0]},
            new CategorySub() {CategorySubName="Pantolon", Category=Categories[0]},
            new CategorySub() {CategorySubName="Gömlek", Category=Categories[0]},
            new CategorySub() {CategorySubName="Saat", Category=Categories[1]},
            new CategorySub() {CategorySubName="Güneş Gözlüğü", Category=Categories[1]},
            new CategorySub() {CategorySubName="Cüzdan", Category=Categories[1]},
            new CategorySub() {CategorySubName="Boxer", Category=Categories[1]},
            new CategorySub() {CategorySubName="Çorap", Category=Categories[1]},
            new CategorySub() {CategorySubName="Forma", Category=Categories[1]},
            new CategorySub() {CategorySubName="Bebek Takımları", Category=Categories[2]},
            new CategorySub() {CategorySubName="Bebek Arabası", Category=Categories[2]},
            new CategorySub() {CategorySubName="Bebek Şampuanı", Category=Categories[2]},
            new CategorySub() {CategorySubName="Bebek Çantası", Category=Categories[2]},
            new CategorySub() {CategorySubName="Yürüteç", Category=Categories[2]},
            new CategorySub() {CategorySubName="Mama Sandalyesi", Category=Categories[2]},
            new CategorySub() {CategorySubName="Avize", Category=Categories[3]},
            new CategorySub() {CategorySubName="Mutfak Takımları", Category=Categories[3]},
            new CategorySub() {CategorySubName="Banyo Takımları", Category=Categories[3]},
            new CategorySub() {CategorySubName="Ev Tekstili", Category=Categories[3]},
            new CategorySub() {CategorySubName="Koşu Bantları", Category=Categories[3]},
            new CategorySub() {CategorySubName="Defter & Kalem", Category=Categories[3]},
            new CategorySub() {CategorySubName="Çay", Category=Categories[4]},
            new CategorySub() {CategorySubName="Kahve", Category=Categories[4]},
            new CategorySub() {CategorySubName="Kahvaltılık", Category=Categories[4]},
            new CategorySub() {CategorySubName="Ağız Bakımı", Category=Categories[4]},
            new CategorySub() {CategorySubName="Cilt Bakımı", Category=Categories[4]},
            new CategorySub() {CategorySubName="Meyve & Sebze", Category=Categories[4]},
            new CategorySub() {CategorySubName="Makyaj", Category=Categories[5]},
            new CategorySub() {CategorySubName="Parfüm & Deodorant", Category=Categories[5]},
            new CategorySub() {CategorySubName="Saç Bakımı", Category=Categories[5]},
            new CategorySub() {CategorySubName="Epilasyon & Traş Ürünleri", Category=Categories[5]},
            new CategorySub() {CategorySubName="Cinsel Sağlık", Category=Categories[5]},
            new CategorySub() {CategorySubName="Vücut Bakımı", Category=Categories[5]},
            new CategorySub() {CategorySubName="Spor Ayakkabı", Category=Categories[6]},
            new CategorySub() {CategorySubName="Günlük Ayakkabı", Category=Categories[6]},
            new CategorySub() {CategorySubName="Terlik", Category=Categories[6]},
            new CategorySub() {CategorySubName="Sırt Çantası", Category=Categories[6]},
            new CategorySub() {CategorySubName="Postacı Çantası", Category=Categories[6]},
            new CategorySub() {CategorySubName="Bel Çantası", Category=Categories[6]},
            new CategorySub() {CategorySubName="Kadın Saat", Category=Categories[7]},
            new CategorySub() {CategorySubName="Erkek Saat", Category=Categories[7]},
            new CategorySub() {CategorySubName="Çocuk Saat", Category=Categories[7]},
            new CategorySub() {CategorySubName="Kolye", Category=Categories[7]},
            new CategorySub() {CategorySubName="Küpe", Category=Categories[7]},
            new CategorySub() {CategorySubName="Bilezik", Category=Categories[7]},
            new CategorySub() {CategorySubName="Bilgisayar & Tablet", Category=Categories[8]},
            new CategorySub() {CategorySubName="Telefon", Category=Categories[8]},
            new CategorySub() {CategorySubName="Oyun Konsolları", Category=Categories[8]},
            new CategorySub() {CategorySubName="Beyaz Eşya", Category=Categories[8]},
            new CategorySub() {CategorySubName="TV & Görüntü & Ses", Category=Categories[8]},
            new CategorySub() {CategorySubName="Veri Depolama", Category=Categories[8]}
        };

        private static Product[] Products =
        {
            new Product() {ProductName="Çiçekli Elbise", UnitPrice=100, UnitsInStock=50, ImageUrl="1.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Pembe Sweatshirt", UnitPrice=120, UnitsInStock=50, ImageUrl="2.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Sincaplı Kazak", UnitPrice=130, UnitsInStock=50, ImageUrl="3.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Siyah T-Shirt", UnitPrice=110, UnitsInStock=50, ImageUrl="4.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Kot Pantolon", UnitPrice=150, UnitsInStock=50, ImageUrl="5.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Beyaz Gömlek", UnitPrice=160, UnitsInStock=50, ImageUrl="6.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Swatch Saat", UnitPrice=1000, UnitsInStock=50, ImageUrl="7.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Rayban Güneş Gözlüğü", UnitPrice=100, UnitsInStock=50, ImageUrl="8.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Deri Cüzdan", UnitPrice=100, UnitsInStock=50, ImageUrl="9.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Siyah Boxer", UnitPrice=100, UnitsInStock=50, ImageUrl="10.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Rick & Morty Çorap", UnitPrice=20, UnitsInStock=50, ImageUrl="11.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Fenerbahçe Forma", UnitPrice=250, UnitsInStock=50, ImageUrl="12.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Pembe Bebek Takımı", UnitPrice=100, UnitsInStock=50, ImageUrl="13.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Tommybaby Bebek Arabası", UnitPrice=100, UnitsInStock=50, ImageUrl="14.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Dalin Bebek Şampuanı", UnitPrice=100, UnitsInStock=50, ImageUrl="15.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Balin Bebek Çantası", UnitPrice=100, UnitsInStock=50, ImageUrl="16.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Tommybaby Yürüteç", UnitPrice=100, UnitsInStock=50, ImageUrl="17.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Tommybaby Mama Sandalyesi", UnitPrice=100, UnitsInStock=50, ImageUrl="18.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Richardson Avize", UnitPrice=100, UnitsInStock=50, ImageUrl="19.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Pearl Mutfak Takımı", UnitPrice=100, UnitsInStock=50, ImageUrl="20.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Pearl Banyo Takımı", UnitPrice=100, UnitsInStock=50, ImageUrl="21.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Home Color Perde", UnitPrice=100, UnitsInStock=50, ImageUrl="22.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Family Koşu Bandı", UnitPrice=100, UnitsInStock=50, ImageUrl="23.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Faber Castell Kalem", UnitPrice=100, UnitsInStock=50, ImageUrl="24.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Filiz Çay", UnitPrice=100, UnitsInStock=50, ImageUrl="25.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Nescafe Kahve", UnitPrice=100, UnitsInStock=50, ImageUrl="26.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Nutella", UnitPrice=100, UnitsInStock=50, ImageUrl="27.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Listerine", UnitPrice=100, UnitsInStock=50, ImageUrl="28.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Arko Nem Krem", UnitPrice=100, UnitsInStock=50, ImageUrl="29.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Elma", UnitPrice=100, UnitsInStock=50, ImageUrl="30.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Maybelline New York Lash", UnitPrice=100, UnitsInStock=50, ImageUrl="31.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Fahrenheit 100ml", UnitPrice=100, UnitsInStock=50, ImageUrl="32.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Elidor Şampuan", UnitPrice=100, UnitsInStock=50, ImageUrl="33.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Gilette Mach 3 Turbo", UnitPrice=100, UnitsInStock=50, ImageUrl="34.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Okey Nirvana", UnitPrice=100, UnitsInStock=50, ImageUrl="35.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Vose Selülit Fırçası", UnitPrice=100, UnitsInStock=50, ImageUrl="36.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Nike Krampon", UnitPrice=100, UnitsInStock=50, ImageUrl="37.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Kinetix Erkek Ayakkabı", UnitPrice=100, UnitsInStock=50, ImageUrl="38.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Lacivert Hastane Terliği", UnitPrice=100, UnitsInStock=50, ImageUrl="39.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="HP Sırt Laptop Çantası", UnitPrice=100, UnitsInStock=50, ImageUrl="40.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Nike Postacı Çantası", UnitPrice=100, UnitsInStock=50, ImageUrl="41.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Polo Deri Bel Çantası", UnitPrice=100, UnitsInStock=50, ImageUrl="42.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Swatch Pembe Saat", UnitPrice=100, UnitsInStock=50, ImageUrl="43.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Swatch Siyah Saat", UnitPrice=100, UnitsInStock=50, ImageUrl="44.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.MaxValue},
            new Product() {ProductName="Swatch Turuncu Çocuk Saat", UnitPrice=100, UnitsInStock=50, ImageUrl="45.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.MaxValue},
            new Product() {ProductName="Gümüş Sincap Kolye", UnitPrice=100, UnitsInStock=50, ImageUrl="46.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.MaxValue},
            new Product() {ProductName="Deniz Yıldızı Küpe", UnitPrice=100, UnitsInStock=50, ImageUrl="47.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.MaxValue},
            new Product() {ProductName="Altın Bilezik", UnitPrice=100, UnitsInStock=50, ImageUrl="48.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Msi Pro Notebook", UnitPrice=100, UnitsInStock=50, ImageUrl="49.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Iphone 11", UnitPrice=100, UnitsInStock=50, ImageUrl="50.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Xbox One", UnitPrice=100, UnitsInStock=50, ImageUrl="51.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Arçelik Buzdolabı", UnitPrice=100, UnitsInStock=50, ImageUrl="52.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="Samsung Televizyon", UnitPrice=100, UnitsInStock=50, ImageUrl="53.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
            new Product() {ProductName="WD M.2 SSD", UnitPrice=100, UnitsInStock=50, ImageUrl="54.jpg", Description="<p>Güzel birşey</p>", DisplayDate=DateTime.Now},
        };

        private static Advertised[] Advertiseds = {
            new Advertised() {WeeklyOrDaily=true, Product=Products[0]},
            new Advertised() {WeeklyOrDaily=true, Product=Products[6]},
            new Advertised() {WeeklyOrDaily=true, Product=Products[12]},
            new Advertised() {WeeklyOrDaily=true, Product=Products[18]},
            new Advertised() {WeeklyOrDaily=true, Product=Products[24]},
            new Advertised() {WeeklyOrDaily=true, Product=Products[30]},
            new Advertised() {WeeklyOrDaily=false, Product=Products[36]},
            new Advertised() {WeeklyOrDaily=false, Product=Products[42]},
            new Advertised() {WeeklyOrDaily=false, Product=Products[48]},
            new Advertised() {WeeklyOrDaily=false, Product=Products[53]},
            new Advertised() {WeeklyOrDaily=false, Product=Products[3]},
            new Advertised() {WeeklyOrDaily=false, Product=Products[50]},
        };

        private static ProductCategorySub[] ProductCategories =
        {
            new ProductCategorySub() {Product= Products[0],CategorySub= CategorySubs[0]},
            new ProductCategorySub() {Product= Products[1],CategorySub= CategorySubs[1]},
            new ProductCategorySub() {Product= Products[2],CategorySub= CategorySubs[2]},
            new ProductCategorySub() {Product= Products[3],CategorySub= CategorySubs[3]},
            new ProductCategorySub() {Product= Products[4],CategorySub= CategorySubs[4]},
            new ProductCategorySub() {Product= Products[5],CategorySub= CategorySubs[5]},
            new ProductCategorySub() {Product= Products[6],CategorySub= CategorySubs[6]},
            new ProductCategorySub() {Product= Products[7],CategorySub= CategorySubs[7]},
            new ProductCategorySub() {Product= Products[8],CategorySub= CategorySubs[8]},
            new ProductCategorySub() {Product= Products[9],CategorySub= CategorySubs[9]},
            new ProductCategorySub() {Product= Products[10],CategorySub= CategorySubs[10]},
            new ProductCategorySub() {Product= Products[11],CategorySub= CategorySubs[11]},
            new ProductCategorySub() {Product= Products[12],CategorySub= CategorySubs[12]},
            new ProductCategorySub() {Product= Products[13],CategorySub= CategorySubs[13]},
            new ProductCategorySub() {Product= Products[14],CategorySub= CategorySubs[14]},
            new ProductCategorySub() {Product= Products[15],CategorySub= CategorySubs[15]},
            new ProductCategorySub() {Product= Products[16],CategorySub= CategorySubs[16]},
            new ProductCategorySub() {Product= Products[17],CategorySub= CategorySubs[17]},
            new ProductCategorySub() {Product= Products[18],CategorySub= CategorySubs[18]},
            new ProductCategorySub() {Product= Products[19],CategorySub= CategorySubs[19]},
            new ProductCategorySub() {Product= Products[20],CategorySub= CategorySubs[20]},
            new ProductCategorySub() {Product= Products[21],CategorySub= CategorySubs[21]},
            new ProductCategorySub() {Product= Products[22],CategorySub= CategorySubs[22]},
            new ProductCategorySub() {Product= Products[23],CategorySub= CategorySubs[23]},
            new ProductCategorySub() {Product= Products[24],CategorySub= CategorySubs[24]},
            new ProductCategorySub() {Product= Products[25],CategorySub= CategorySubs[25]},
            new ProductCategorySub() {Product= Products[26],CategorySub= CategorySubs[26]},
            new ProductCategorySub() {Product= Products[27],CategorySub= CategorySubs[27]},
            new ProductCategorySub() {Product= Products[28],CategorySub= CategorySubs[28]},
            new ProductCategorySub() {Product= Products[29],CategorySub= CategorySubs[29]},
            new ProductCategorySub() {Product= Products[30],CategorySub= CategorySubs[30]},
            new ProductCategorySub() {Product= Products[31],CategorySub= CategorySubs[31]},
            new ProductCategorySub() {Product= Products[32],CategorySub= CategorySubs[32]},
            new ProductCategorySub() {Product= Products[33],CategorySub= CategorySubs[33]},
            new ProductCategorySub() {Product= Products[34],CategorySub= CategorySubs[34]},
            new ProductCategorySub() {Product= Products[35],CategorySub= CategorySubs[35]},
            new ProductCategorySub() {Product= Products[36],CategorySub= CategorySubs[36]},
            new ProductCategorySub() {Product= Products[37],CategorySub= CategorySubs[37]},
            new ProductCategorySub() {Product= Products[38],CategorySub= CategorySubs[38]},
            new ProductCategorySub() {Product= Products[39],CategorySub= CategorySubs[39]},
            new ProductCategorySub() {Product= Products[40],CategorySub= CategorySubs[40]},
            new ProductCategorySub() {Product= Products[41],CategorySub= CategorySubs[41]},
            new ProductCategorySub() {Product= Products[42],CategorySub= CategorySubs[42]},
            new ProductCategorySub() {Product= Products[43],CategorySub= CategorySubs[43]},
            new ProductCategorySub() {Product= Products[44],CategorySub= CategorySubs[44]},
            new ProductCategorySub() {Product= Products[45],CategorySub= CategorySubs[45]},
            new ProductCategorySub() {Product= Products[46],CategorySub= CategorySubs[46]},
            new ProductCategorySub() {Product= Products[47],CategorySub= CategorySubs[47]},
            new ProductCategorySub() {Product= Products[48],CategorySub= CategorySubs[48]},
            new ProductCategorySub() {Product= Products[49],CategorySub= CategorySubs[49]},
            new ProductCategorySub() {Product= Products[50],CategorySub= CategorySubs[50]},
            new ProductCategorySub() {Product= Products[51],CategorySub= CategorySubs[51]},
            new ProductCategorySub() {Product= Products[52],CategorySub= CategorySubs[52]},
            new ProductCategorySub() {Product= Products[53],CategorySub= CategorySubs[53]},
        };

    }
}
