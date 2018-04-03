using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FlatAgency.App_Data.DB;
using FlatAgency.Models;

namespace FlatAgency.App_Data
{
    internal class DbAction : IDbAction
    {
        DB_A37EBA_flatagencyContext db;

        public DbAction(DB_A37EBA_flatagencyContext context)
        {
            db = context;
        }

        public void DelateFlat(int id)
        {
            try
            {
                var flat = db.Flat.FirstOrDefault(x => x.FlatId == id);
                if (flat != null)
                {
                    flat.IsDelete = true;
                    flat.DateDelete = DateTime.UtcNow;
                    db.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                Debugger.Log(1, "DB Action", ex.Message);
            }
        }

        public List<string> GetAllDistrict()
        {
            try
            {
                return db.District.Select(x => x.Name).ToList();
            }
            catch (Exception ex)
            {
                Debugger.Log(1, "DB Action", ex.Message);
            }

            return new List<string>();
        }

        public List<string> GetAllStreets()
        {
            try
            {
                return db.Street.Select(x => x.Name).ToList();
            }
            catch (Exception ex)
            {
                Debugger.Log(1, "DB Action", ex.Message);
            }
            return new List<string>();

        }

        public Models.Flat GetFlatById(int id)
        {

            try
            {         
                var flat = db.Flat.FirstOrDefault(x => x.FlatId == id);
               
                if (flat == null)
                {
                    return null;
                }
                flat.FlatClass = db.FlatClass.FirstOrDefault(x => x.FlatClassId == flat.FlatClassId);
                flat.Street = db.Street.FirstOrDefault(x => x.StreetId == flat.StreetId);
                flat.Street.District = db.District.FirstOrDefault(x => x.DistrictId == flat.Street.DistrictId);
                return new Models.Flat()
                {
                    Id = flat.FlatId,
                    Address = $"{flat.Street.Name} {flat.HouseNumber}",
                    Price = flat.Price,
                    Class = flat.FlatClass.Name,
                    DateCreation = flat.DateCreate,
                    District = flat.Street.District.Name,
                    Floor = flat.Floor,
                    Rooms = flat.Rooms,
                    Square = flat.Square
                };
            }
            catch (Exception ex)
            {
                db.FlatClass.Add(new DB.FlatClass() { Name = "Test2 "+ex.Message+ex.Source });
                db.SaveChanges();
                Debugger.Log(1, "DB Action", ex.Message);
            }

            return null;


        }

        public List<Models.Flat> GetFlats(int skip, int count)
        {
            try
            {
                return db.Flat.Skip(skip).Take(count).Select(flat => new Models.Flat()
                {
                    Id = flat.FlatId,
                    Address = $"{flat.Street.Name} {flat.HouseNumber}",
                    Price = flat.Price,
                    Class = flat.FlatClass.Name,
                    DateCreation = flat.DateCreate,
                    District = flat.Street.District.Name,
                    Floor = flat.Floor,
                    Rooms = flat.Rooms,
                    Square = flat.Square
                }).ToList();
            }
            catch (Exception ex)
            {
                Debugger.Log(1, "DB Action", ex.Message);
            }
            return new List<Models.Flat>();
        }

        public List<Models.Flat> GetFlatsByFilter(int skip, int count, List<Models.District> district, decimal maxprice, decimal minprice, String flatClass)
        {
            try
            {

           

                var filter = db.Flat.Where(x => x.Price >= minprice && x.Price <= maxprice);
                if (flatClass != null)
                {
                    var classObj = db.FlatClass.FirstOrDefault(x => x.Name == flatClass);
                    if (classObj != null)
                    {
                        filter = filter.Where(x => x.FlatClassId == classObj.FlatClassId);
                    }
                }
                if (district != null && district.Count > 0)
                {
                    var districts = db.District.Where(x => district.Any(y => y.Id == x.DistrictId));
                    filter = filter.Where(x => district.Any(y => y.Id == x.Street.DistrictId));
                }


                return filter.Skip(skip).Take(count).Select(flat=>new Models.Flat()
                {
                    Id = flat.FlatId,
                    Address = $"{flat.Street.Name} {flat.HouseNumber}",
                    Price = flat.Price,
                    Class = flat.FlatClass.Name,
                    DateCreation = flat.DateCreate,
                    District = flat.Street.District.Name,
                    Floor = flat.Floor,
                    Rooms = flat.Rooms,
                    Square = flat.Square
                }).ToList(); 
                    
            }
            catch (Exception ex)
            {

                Debugger.Log(1, "DB Action", ex.Message);
            }
            return new List<Models.Flat>();
        }

        public List<Models.Flat> GetTopFlats(int count)
        {
            try
            {
                List<Models.Flat> result = new List<Models.Flat>();

                var taked = db.Flat.Take(count).OrderByDescending(x => x.Price);

                foreach (var flat in taked)
                {
                    result.Add(new Models.Flat()
                    {
                        Id = flat.FlatId,
                        Address = $"{flat.Street.Name} {flat.HouseNumber}",
                        Price = flat.Price,
                        Class = flat.FlatClass.Name,
                        DateCreation = flat.DateCreate,
                        District = flat.Street.District.Name,
                        Floor = flat.Floor,
                        Rooms = flat.Rooms,
                        Square = flat.Square
                    });
                }

                return result;
            }
            catch (Exception ex)
            {

                Debugger.Log(1, "DB Action", ex.Message);
            }

            return new List<Models.Flat>();
        }
    }
}
