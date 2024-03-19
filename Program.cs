using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.Design.Serialization;
using System.Xml.Linq;
using TurboAzORM.Enums;
using TurboAzORM.Helper;
using TurboAzORM.Models.DataContexts;
using TurboAzORM.Models.Entities;

namespace TurboAzORM
{
    internal class Program
    {
        static TurbaAzDbContext db = new TurbaAzDbContext();
        static void Main(string[] args)
        {
        l1:
            MenuOption menuOption = Helper.Helper.ChooseOption<MenuOption>("Choose from list ", "List must be choose from list");
            switch (menuOption)
            {
                case MenuOption.AddBrand:
                    AddBrand();
                    goto l1;
                    break;
                case MenuOption.DeleteBrand:
                    DeleteBrand();
                    goto l1;
                    break;
                case MenuOption.EditBrand:
                    EditBrand();
                    goto l1;
                    break;
                case MenuOption.GetAllBrands:
                    GetAllBrands();
                    goto l1;
                    break;
                case MenuOption.AddModel:
                    AddModel(); //Xeta var sorus!
                    goto l1;
                    break;
                case MenuOption.DeleteModel:
                    DeleteModel();
                    goto l1;
                    break;
                case MenuOption.EditModel:
                    EditModel();
                    goto l1;
                    break;
                case MenuOption.GetAllModels:
                    GetAllModels();
                    goto l1;
                    break;
                case MenuOption.GetModelById:
                    GetModelById();
                    goto l1;
                    break;
                case MenuOption.AddAnnouncement:
                    AddAnnouncement();
                    goto l1;
                    break;
                case MenuOption.DeleteAnnouncement:
                    DeleteAnnouncement();
                    goto l1;
                    break;
                case MenuOption.EditAnnouncement:
                    EditAnnouncement();
                    goto l1;
                    break;
                case MenuOption.GetAllAnnouncements:
                    GetAllAnnouncements();
                    goto l1;
                    break;
                case MenuOption.GetAnnouncementById:
                    GetAnnouncementById();
                    goto l1;
                    break;
                default:
                    break;
            }
        }

        public static void GetAnnouncementById()
        {
            foreach (var item in db.announcements.ToList())
            {
                Console.WriteLine($"Announcement {item.Id}");
            }
            var annId = Helper.Helper.ReadInt("Inclde ID", "Wrong!");
            var chechAnnId = db.announcements.FirstOrDefault(a => a.Id == annId);
            if (chechAnnId == null)
            {
                Console.WriteLine($"{chechAnnId} id is not found");
            }


            Console.WriteLine($"{chechAnnId}");
        }

        private static void EditAnnouncement()
        {
            foreach (var item in db.announcements.ToList())
            {
                if (item.DeletedAt == null)
                    Console.WriteLine(item);
            }
            
            var checkann = Helper.Helper.ReadInt("Choose id in which you want to edit", "You choose incorrectly");
            Announcement? announcement = db.announcements.FirstOrDefault(m => m.Id == checkann);
            if (announcement != null)
            {
                int modelId;
                double price;
                double march;
                int fueltypeenum;
                int gear;
                int transmissionsEnum;
                Console.WriteLine("If you want create announcement Select one of the models");
                foreach (var item in db.models.ToList())
                {
                    Console.WriteLine($"Id: {item.Id} Name: {item.Name}");
                }
            l1:
                modelId = Helper.Helper.ReadInt("Enter the model of Id", "You enter incorrectly");
                var checkId = db.models.ToList().FirstOrDefault(x => x.Id == modelId);
                if (checkId == null)
                {
                    Console.WriteLine("There is no model with the Id you selected!");
                    goto l1;
                }
            l2:
                price = Helper.Helper.ReadDouble("Enter the Price", "You entered incorrectly");
                if (price == 0)
                {
                    Console.WriteLine("The Price must be entered");
                    goto l2;
                }
            l3:
                march = Helper.Helper.ReadDouble("Enter The March", "You entered incorretly");
                if (march < 0)
                {
                    Console.WriteLine("The march is not to be negative");
                    goto l3;
                }


                var fuelType = Helper.Helper.ChooseOption<FuelType>("Choose fuel type: ");


                var gearType = Helper.Helper.ChooseOption<Gear>("Choose gear type: ");

                var category = Helper.Helper.ChooseOption<Categories>("Choose category type: ");



                var transmissionsType = Helper.Helper.ChooseOption<Transmissions>("Choose transmission type");


                announcement.Transmissions = transmissionsType;
                announcement.Category = category;
                announcement.Gear = gearType;
                announcement.FuelType = fuelType;
                announcement.CreatedAt = DateTime.Now;
                announcement.CreatedBy = 1;
                announcement.Year = 1;
                announcement.LastModifiedAt = DateTime.Now;
                db.announcements.Update(announcement);
                db.SaveChanges();

            }
        }

        private static void GetAllAnnouncements()
        {
            foreach (var item in db.announcements.ToList())
            {
                if (item.DeletedAt == null)
                    Console.WriteLine(item);
            }
            if (db.announcements.ToList().Count == 0)
            {
                Console.WriteLine("Annocmnet not included!");
            }


        }

        public static void DeleteAnnouncement()
        {
            foreach (var item in db.announcements.ToList())
            {
                Console.WriteLine($"{item}");
            }
        l8:
            var dAnnoucnment = Helper.Helper.ReadInt("Enter the id in which you want to delete", "You enter incorrectly");
            Announcement ann = db.announcements.FirstOrDefault(a => a.Id == dAnnoucnment);
            if (ann != null)
            {
                ann.DeletedAt = DateTime.Now;
                ann.DeletedBy = 1;
            }
            else
            {
                Console.WriteLine("Wrong Id");
                goto l8;
            }
            db.announcements.Remove(ann);
            db.SaveChanges();
        }

        public static void AddAnnouncement()
        {
            int modelId;
            double price;
            double march;
            int fueltypeenum;
            int gear;
            int transmissionsEnum;
            Console.WriteLine("If you want create announcement Select one of the models");
            foreach (var item in db.models.ToList())
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name}");
            }
        l1:
            modelId = Helper.Helper.ReadInt("Enter the model of Id", "You enter incorrectly");
            var checkId = db.models.ToList().FirstOrDefault(x => x.Id == modelId);
            if (checkId == null)
            {
                Console.WriteLine("There is no model with the Id you selected!");
                goto l1;
            }
        l2:
            price = Helper.Helper.ReadDouble("Enter the Price", "You entered incorrectly");
            if (price == 0)
            {
                Console.WriteLine("The Price must be entered");
                goto l2;
            }
        l3:
            march = Helper.Helper.ReadDouble("Enter The March", "You entered incorretly");
            if (march < 0)
            {
                Console.WriteLine("The march is not to be negative");
                goto l3;
            }


            var fuelType = Helper.Helper.ChooseOption<FuelType>("Choose fuel type: ");


            var gearType = Helper.Helper.ChooseOption<Gear>("Choose gear type: ");

            var category = Helper.Helper.ChooseOption<Categories>("Choose category type: ");



            var transmissionsType = Helper.Helper.ChooseOption<Transmissions>("Choose transmission type");

            Announcement announcement = new Announcement();
            announcement.Transmissions = transmissionsType;
            announcement.Category = category;
            announcement.Gear = gearType;
            announcement.FuelType = fuelType;
            announcement.CreatedAt = DateTime.Now;
            announcement.CreatedBy = 1;
            announcement.Year = 1;

            Console.Clear();
            db.announcements.Add(announcement);
            db.SaveChanges();
            Console.WriteLine("New announcement was added");

          
            var newQuery = (from a in db.announcements
                            join m in db.models on a.ModelId equals m.Id
                            join b in db.Brands on a.BrandId equals b.Id
                            where m.DeletedAt == null && b.DeletedAt == null && a.DeletedAt == null
                            select new { a.DeletedAt, a.Id, a.Year, a.FuelType, a.Gear, a.Transmissions, a.March, a.Price, modelName = m.Name, brandName = b.Name, brandId = b.Id }).ToList();
            Console.WriteLine("Announcments");
            foreach (var item in newQuery)
            {
                Console.WriteLine($"BrandName: {item.brandName}\nModelName: {item.modelName}\nMArch: {item.March}\nPrice: {item.Price}\nFuelType: {item.FuelType}\nGear: {item.Gear}\nTransmissions: {item.Transmissions} Year: {item.Year} DeletedAt: {item.DeletedAt}\nId: {item.Id}BrandId {item.brandId}");
            }



        }

        private static void GetModelById()
        {
            foreach (var item in db.models.ToList())
            {
                Console.WriteLine($"ID: {item.Id}");
            }
        l1:
            int modelId = Helper.Helper.ReadInt("Add models Id", "You enter incorrectly");
            var checkId = db.models.ToList().FirstOrDefault(x => x.Id == modelId);
            if (checkId is null)
            {
                Console.WriteLine($"{modelId} is not found");
                goto l1;
            }
            Console.WriteLine($"Id: {checkId.Id} Name: {checkId.Name}");
        }

        public static void GetAllModels()
        {
            if (db.models.ToList().Count > 0)
            {
                foreach (var item in db.models.ToList())
                {
                    Console.WriteLine($"Name: {item.Name} Id: {item.Id} {item.CreatedAt} ");
                }
            }
            else
            {
                Console.WriteLine("Models are empty!");
            };

        }

        //    int brandId;

        //        foreach (var brand in db.Brands.ToList())
        //        {
        //            Console.WriteLine($"Id: {brand.Id} Name: {brand.Name}");
        //        }
        //l1:
        //        brandId = Helper.Helper.ReadInt("Enter the Id in which you want to edit", "You enter wrong Id");
        //        var brId = db.Brands.FirstOrDefault(m => m.Id == brandId);
        //        if (brId == null)
        //        {
        //            Console.WriteLine("The id you selected does not exist in the database");
        //            goto l1;
        //        }

        //string newBradName = Helper.Helper.ReadString("Add new brand name", "You enter wrong");
        //brId.Name = newBradName;
        //db.Brands.Update(brId);
        //db.SaveChanges();

        public static void EditModel()
        {
            int modelId;
            foreach (var item in db.models.ToList())
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name}");
            }
        l1:
            modelId = Helper.Helper.ReadInt("Enter the Id in which you want to edit", "You entered incorrectly");
            var modd = db.models.ToList().FirstOrDefault(m => m.Id == modelId);
            if (modd == null)
            {
                Console.WriteLine("The id you selected does not exist in the database");
                goto l1;
            }
            string newModelName = Helper.Helper.ReadString("Add new model name", "You entered incorrectly");
            foreach (var item in db.models.ToList())
            {
                Console.WriteLine($"Id - {item.Id}, Adi - {item.Name}");
            }
            Console.WriteLine("Edited succesfully");
            modd.Name = newModelName;
            db.models.Update(modd);
            db.SaveChanges();

        }

        //        List<Brand> brands = db.Brands.ToList();
        //            foreach (Brand brand in brands)
        //            {
        //                Console.WriteLine($"{brand.Id} {brand.Name}");
        //            }
        //    int userId;
        //    l1:
        //            userId = Helper.Helper.ReadInt("Choose brand Id: ", "Brand Id must be choose from list");
        //            var br = db.Brands.FirstOrDefault(m => m.Id == userId);
        //            if (br is null)
        //            {
        //                Console.WriteLine("Wrong Id. Please choose correct id");
        //                goto l1;
        //            }

        //db.Brands.Remove(br);
        //db.SaveChanges();

        public static void DeleteModel()
        {
            int deleteId;
            foreach (var item in db.models.ToList())
            {
                Console.WriteLine($"Name: {item.Name} Id: {item.Id}");
            }
        l1:
            deleteId = Helper.Helper.ReadInt("Silmek istediyiniz modelin Id-sini daxil edin!", "You entered incorrectly");
            var md = db.models.ToList().FirstOrDefault(m=>m.Id == deleteId);
            if (md == null)
            {
                Console.WriteLine("The model with the ID you entered is not available in the system!");
                goto l1;

            }
            db.models.Remove(md);
            db.SaveChanges();


        }

        public static void AddModel()
        {
            var brandlist = db.Brands.ToList();
            if (brandlist.Count == 0)
            {
                Console.WriteLine("Thera are not brand in database! Please enter brand");
                return;
            }
            string modelName = Helper.Helper.ReadString("Add new model", "You entered incorrectly");
            int brandId;
            foreach (var brand in brandlist)
            {
                Console.WriteLine($"Id: {brand.Id} Name: {brand.Name}");
            }
        l1:
            brandId = Helper.Helper.ReadInt("Select Make of Model", "You entered incorrectly");
            var brand1 = brandlist.FirstOrDefault(m => m.Id == brandId);
            if (brand1 == null)
            {
                Console.WriteLine("You have entered the wrong ID!");
                goto l1;
            }

            Model model = new Model()
            {
                Name = modelName,
                BrandId = brandId,
                CreatedAt = DateTime.Now,
            };
            db.models.Add(model);
            db.SaveChanges();
            Console.WriteLine("Added Succesfully");


        }

        public static void GetAllBrands()
        {
            foreach (var brand in db.Brands.ToList())
            {
                Console.WriteLine($"Id: {brand.Id} Name: {brand.Name}");
            }
            if (db.Brands.ToList().Count == 0)
            {
                Console.WriteLine("Brands are not in db!");
            }
        }

        public static void EditBrand()
        {
            int brandId;

            foreach (var brand in db.Brands.ToList())
            {
                Console.WriteLine($"Id: {brand.Id} Name: {brand.Name}");
            }
        l1:
            brandId = Helper.Helper.ReadInt("Enter the Id in which you want to edit", "You enter wrong Id");
            var brId = db.Brands.FirstOrDefault(m => m.Id == brandId);
            if (brId == null)
            {
                Console.WriteLine("The id you selected does not exist in the database");
                goto l1;
            }

            string newBradName = Helper.Helper.ReadString("Add new brand name", "You enter wrong");
            brId.Name = newBradName;
            db.Brands.Update(brId);
            db.SaveChanges();


        }

        public static void DeleteBrand()
        {

            List<Brand> brands = db.Brands.ToList();
            foreach (Brand brand in brands)
            {
                Console.WriteLine($"{brand.Id} {brand.Name}");
            }
            int userId;
        l1:
            userId = Helper.Helper.ReadInt("Choose brand Id: ", "Brand Id must be choose from list");
            var br = db.Brands.FirstOrDefault(m => m.Id == userId);
            if (br is null)
            {
                Console.WriteLine("Wrong Id. Please choose correct id");
                goto l1;
            }

            db.Brands.Remove(br);
            db.SaveChanges();




        }

        public static void AddBrand()
        {
            Brand brand = new Brand();
            string name;
            name = Helper.Helper.ReadString("Add new brand name: ", "Yeniden cehd edin");
            brand.Name = name;
            db.Add(brand);
            db.SaveChanges();


        }
    }
}
