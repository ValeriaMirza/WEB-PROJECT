﻿using System;
using System.Collections.Generic;
using System.Linq;
using eUseControl.DomainModels;

namespace eUseControl.Repositories
{
    public interface IUsersRepository
    {
        void InsertUser(User u);
        void UpdateUserDetails(User u);
        void UpdateUserPassword(User u);
        void DeleteUser(int uid);
        List<User> GetUsers();
        List<User> GetUsersByEmailAndPassword(string Email, string Password);
        List<User> GetUsersByEmail(string Email);
        List<User> GetUsersByUserID(int UserID);
        int GetLatestUserID();
    }
    public class UsersRepository : IUsersRepository
    {
        eUseControlDatabaseDbContext db;

        public UsersRepository()
        {
            db = new eUseControlDatabaseDbContext();
        }

        public void InsertUser(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }

        public void UpdateUserDetails(User u)
        {
            User us = db.Users.Where(temp => temp.UserID == u.UserID).FirstOrDefault();
            if (us != null)
            {
                us.UserName = u.UserName;
                db.SaveChanges();
            }
        }

        public void UpdateUserPassword(User u)
        {
            User us = db.Users.Where(temp => temp.UserID == u.UserID).FirstOrDefault();
            if (us != null)
            {
                us.PasswordHash = u.PasswordHash;
                db.SaveChanges();
            }
        }

        public void DeleteUser(int uid)
        {
            User us = db.Users.Where(temp => temp.UserID == uid).FirstOrDefault();
            if (us != null)
            {
                db.Users.Remove(us);
                db.SaveChanges();
            }
        }

        public List<User> GetUsers()
        {
            List<User> us = db.Users.Where(temp => temp.IsAdmin == false).OrderBy(temp => temp.UserName).ToList();
            return us;
        }

        public List<User> GetUsersByEmailAndPassword(string Email, string PasswordHash)
        {
            List<User> us = db.Users.Where(temp => temp.Email == Email && temp.PasswordHash == PasswordHash).ToList();
            return us;
        }

        public List<User> GetUsersByEmail(string Email)
        {
            List<User> us = db.Users.Where(temp => temp.Email == Email).ToList();
            return us;
        }

        public List<User> GetUsersByUserID(int UserID)
        {
            List<User> us = db.Users.Where(temp => temp.UserID == UserID).ToList();
            return us;
        }

        public int GetLatestUserID()
        {
            int uid = db.Users.Select(temp => temp.UserID).Max();
            return uid;
        }
    }
}

