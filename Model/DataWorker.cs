using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using AutoSound.Model.ModelDb;

namespace AutoSound.Model;


public static class DataWorker
{
    //Check user
    public static int LoginVerification(string login,string pass)
    {
        using AutoSoundDbContext db = new();
        Employee? user = null;
        int result = 0;
        user = db.Employees
            .FirstOrDefault(e => e.Security.Login == login && e.Security.Password == pass);
        if (user != null) result = user.Id;
        return result;
    }
    //Get Employee

    public static List<Employee> GetEmployees()
    {
        using AutoSoundDbContext db = new();
        var result = db.Employees
            .ToList();
        return result;
    }
    // Add Employee

    public static void AddEmployee
        (string name, string surname, string secondname, string post, string login, string passoword)
    {
        using AutoSoundDbContext db = new();

        var allsec = db.Securities.ToList();
        var allpost = db.Posts.ToList();
        var allemp = db.Employees.ToList();

        var temp = allsec.FirstOrDefault(s => s.Login == login && s.Password == passoword);

        if (temp == null)
        {
            Security newSecurity = new()
            {
                Login = login,
                Password = passoword
            };
            db.Securities.Add(newSecurity);
            db.SaveChanges();
            temp = allsec
                .FirstOrDefault(s => s.Login == login)!;
            var secid = temp.Id;

            var idpost = allpost.FirstOrDefault(p => p.Title == post)!.Id;

            Employee newEmployee = new()
            {
                Name = name,
                SurName = surname,
                SecondName = secondname,
                PostId = idpost,
                SecurityId = secid
            };
            db.Employees.Add(newEmployee);
            db.SaveChanges();
            db.Dispose();
        }
        else
        {
            MessageBox.Show("Ошибка изменить данне пользователя,обратитесь к администратору","Ошибка",MessageBoxButton.OK);
        }

    }
    //Edit Employee

    public static void EditUserData(int id, string name, string surname, string secondname, string post, string login, string passoword)
    {
        using AutoSoundDbContext db = new();

        var allsec = db.Securities.ToList();
        var allpost = db.Posts.ToList();
        var allemp = db.Employees.ToList();

        var temp = allemp.FirstOrDefault(e => e.Id == id);
        if (temp != null)
        {
            temp.Name = name;
            temp.SurName = surname;
            temp.SecondName = secondname;
            temp.PostId = allpost.FirstOrDefault(p => p.Title == post)!.Id;

            db.Employees.Add(temp);
            db.SaveChanges();
        }
        else
        {
          MessageBox.Show("Ошибка создания пользвателя,обратитесь к администратору", "Ошибка", MessageBoxButton.OK);
        }
    }
    //Delete Employee

    public static void DeleteUser(int id)
    {
        using AutoSoundDbContext db = new() ;
        var temp = db.Employees.Find(id);
        if (temp != null)
        {
            db.Employees.Remove(temp);
            db.SaveChanges();
        }
        else
        {
            MessageBox.Show("Произошел сбой,данный пользователь не найден", "Ошибка", MessageBoxButton.OK);
        }
        
    }
    // Get Stock

    public static List<Stock> GetStock()
    {
        using AutoSoundDbContext db = new();
        List<Stock> temp = db.Stocks.ToList();
        return temp;
    }
    // Edit Stock

    public static void EditStock(List<Stock> newStocks)
    {
        using AutoSoundDbContext db = new();
        Stock SaveStock = new();

        foreach (var v in newStocks)
        {
            db.Stocks.Update(v);
        }

        db.SaveChanges();
    }
    //Set Request

    public static void SetRequest(List<Stock> newRequest)
    {
        using AutoSoundDbContext db = new();
        foreach (var v in newRequest)
        {
            db.Stocks.Add(v);
        }

        db.SaveChanges();
    }
    // Get Receiving

    public static List<Stock> GetReceiving()
    {
        using AutoSoundDbContext db = new() ;
        var result = db.Stocks.Where(s => s.Status == "Заказано").ToList();
        return result;
    }
    // Set Receiving

    public static void SetReceiving(List<Stock> newData)
    {
        using AutoSoundDbContext db = new();
        foreach (var v in newData)
        {
            db.Stocks.Update(v);
        }

        db.SaveChanges();

    }
    //Selling
}