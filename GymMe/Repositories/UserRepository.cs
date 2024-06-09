﻿using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
    public class UserRepository
    {
        public static void CreateUser(MsUser newUser)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();

            db.MsUsers.Add(newUser);
            db.SaveChanges();
        }

        public static bool IsUnique(string username)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            MsUser user = (from us in db.MsUsers
                           where us.UserName == username
                           select us).FirstOrDefault();
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsExist(string username, string password)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            MsUser user = (from us in db.MsUsers
                           where us.UserName == username && us.UserPassword == password
                           select us).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static MsUser GetUserById(string id)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            int idInt = Convert.ToInt32(id);
            MsUser user = (from us in db.MsUsers
                           where us.UserID == idInt
                           select us).FirstOrDefault();
            return user;
        }

        public static MsUser GetUserByUsername(string username)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            MsUser user = (from us in db.MsUsers
                           where us.UserName == username
                           select us).FirstOrDefault();
            return user;
        }

        public static string GetUserRole(string id)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            int idInt = Convert.ToInt32(id);
            MsUser user = (from us in db.MsUsers
                           where us.UserID == idInt
                           select us).FirstOrDefault();
            return user.UserRole;
        }
        public static List<MsUser> GetUsers()
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            List<MsUser> users = (from user in db.MsUsers where user.UserRole == "Customer" select user).ToList();
            return users;
        }

        public static string GetPassword(string id)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            int idInt = Convert.ToInt32(id);
            MsUser user = (from us in db.MsUsers
                           where us.UserID == idInt
                           select us).FirstOrDefault();
            return user.UserPassword;
        }

        public static void UpdateUserProfile(string id, string username, string email, string gender, DateTime bod)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            int idInt = Convert.ToInt32(id);
            MsUser user = (from us in db.MsUsers
                           where us.UserID == idInt
                           select us).FirstOrDefault();
            user.UserName = username;
            user.UserEmail = email;
            user.UserGender = gender;
            user.UserDOB = bod;
            db.SaveChanges();
        }
        public static void UpdateUserCredential(string id, string password)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            int idInt = Convert.ToInt32(id);
            MsUser user = (from us in db.MsUsers
                           where us.UserID == idInt
                           select us).FirstOrDefault();
            user.UserPassword = password;
            db.SaveChanges();
        }

    }
}