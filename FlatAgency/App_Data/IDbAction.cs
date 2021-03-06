﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlatAgency.Models;


namespace FlatAgency.App_Data
{
    public interface IDbAction
    {
        Flat GetFlatById(int id);
        List<string> GetAllDistrict();
        List<string> GetAllStreets();
        void DelateFlat(int id);
        List<Flat> GetTopFlats(int count);
        List<Flat> GetFlatsByFilter(int skip, int count, List<District> district, Decimal maxprice, Decimal minprice, String flatClass);
        List<Flat> GetFlats(int skip, int count);
        int GetMaxPrice();
        double GetMaxSquare();

    }
}
